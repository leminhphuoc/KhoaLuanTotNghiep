﻿using FonNature.Services.Extension;
using Models.Entity;
using Models.Model;
using Models.Repository;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System;

namespace FonNature.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpClientService _httpService;
        private readonly IFileHandlerService _fileHandlerService;
        private readonly IProductAdminRepository _productRepository;
        private readonly ICouponCodeRepository _couponCodeRepository;
        public OrderService(IOrderRepository orderRepository, IHttpClientService httpService, IFileHandlerService fileHandlerService, IProductAdminRepository productRepository, ICouponCodeRepository couponCodeRepository)
        {
            _orderRepository = orderRepository;
            _httpService = httpService;
            _fileHandlerService = fileHandlerService;
            _productRepository = productRepository;
            _couponCodeRepository = couponCodeRepository;
        }

        public long CreateOrder(List<ProductInCart> productInCarts, long clientAccountId, ShippingAddress shippingAddress, string paymentMethod, string couponCode = null)
        {
            try
            {
                var discountValue = (decimal)0;
                if(!string.IsNullOrWhiteSpace(couponCode))
                {
                    var coupon = _couponCodeRepository.GetCouponCode(couponCode);
                    if(coupon != null)
                    {
                        var remainingQuantity = _couponCodeRepository.ReduceQuantity(couponCode);
                        if(remainingQuantity != -1)
                        {
                            discountValue = coupon.DiscountValue;
                        }

                    }
                }

                var order = new Order() { ClientAccountId = clientAccountId , ShippingAddress = shippingAddress.ParseToJson() , PaymentMethod = paymentMethod, CouponCode = couponCode, Discount = discountValue };
                var idOrder = _orderRepository.CreateOrder(order);
                var subTotal = (decimal)0;
                foreach (var product in productInCarts)
                {
                    var orderInformation = new OrderInformation()
                    {
                        IdOrder = idOrder,
                        IdProduct = product.itemId,
                        Quantity = product.quantity
                    };
                    _orderRepository.CreateOrderInformation(orderInformation);

                    var productInDb = _productRepository.GetDetail(product.itemId);
                    subTotal += productInDb.promotionPrice == null ? (productInDb.price.Value * product.quantity) : (productInDb.promotionPrice.Value * product.quantity);
                }

                _orderRepository.UpdatePrice(order, subTotal, discountValue);
                return idOrder;
            }
            catch
            {
                return 0;
            }
        }

        public MomoPaymentResponse PaymentByMomo(long orderId, string returnUrl)
        {
            if(orderId == 0 || string.IsNullOrWhiteSpace(returnUrl))
            {
                return null;
            }

            var order = _orderRepository.GetOrder(orderId);
            var orderInfo = string.Empty;
            var orderInformations = _orderRepository.GetOrderInfors(orderId);

            if(orderInformations != null && orderInformations.Any())
            {
                foreach(var info in orderInformations)
                {
                    var productInOrder = _productRepository.GetDetail(info.IdProduct);
                    if(productInOrder == null)
                    {
                        continue;
                    }

                    orderInfo += productInOrder.name + "  x" + info.Quantity + "\n";
                }
            }

            if(order == null)
            {
                return null;
            }

            var config = _fileHandlerService.ReadJsonFile<EnvConfig>("/App_Config/configMomo.json");
            var orderIdstring = config.Enviroment + orderId;
            var amount = order.GrandTotal;
            
            var notifyurl = "https://webhook.site/23c22149-0cd9-4108-8228-44b20a93b8f7";
            var extraData = "Test";

            string rawHash = "partnerCode=" +
                Constant.Payment.MoMo.PartnerCode + "&accessKey=" +
                Constant.Payment.MoMo.AccessCode + "&requestId=" +
                orderId + "&amount=" +
                amount + "&orderId=" +
                orderIdstring + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            var ipnUrl = "https://webhook.site/5e592244-d031-48fc-be99-033cf9b08c44";
            string rawHashv2 = "accessKey=" +
                Constant.Payment.MoMo.AccessCode + "&amount=" +
                amount + "&extraData=" +
                extraData + "&ipnUrl=" + ipnUrl + "&orderId=" +
                orderIdstring + "&orderInfo=" +
                orderInfo + "&partnerCode=" +
                config.PartnerCode + "&redirectUrl=" + returnUrl + "&requestId=" +
                "MM" + GenerateNumber() + "&requestType=" +
                config.RequestType;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            var signature = crypto.signSHA256(rawHashv2, Constant.Payment.MoMo.SecrectKey);
            if (string.IsNullOrWhiteSpace(signature))
            {
                return null;
            }

            HttpContext.Current.Session[Constant.SignatureSession] = signature;
            var paymentRequest = new MomoPaymentRequest()
            {
                AccessKey = config.AccessCode,
                Amount = (long)amount,
                ExtraData = extraData,
                OrderId = orderIdstring,
                OrderInfo = orderInfo,
                PartnerCode = config.PartnerCode,
                RedirectUrl = returnUrl,
                RequestId = "MM" + GenerateNumber(),
                RequestType = config.RequestType,
                Signature = signature,
                IpnUrl = ipnUrl
            };

            return _httpService.Post<MomoPaymentResponse>(config.RequestUrl, paymentRequest);
        }

        private string GenerateNumber()
        {
            var random = new Random();
            var r = "";
            for (int i = 1; i < 11; i++)
            {
                r += random.Next(0, 13).ToString();
            }

            return r;
        }
    }
}