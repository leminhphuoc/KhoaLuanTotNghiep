using FonNature.Services.Extension;
using Models.Entity;
using Models.Model;
using Models.Repository;
using System.Collections.Generic;
using System.Web;

namespace FonNature.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpClientService _httpService;
        public OrderService(IOrderRepository orderRepository, IHttpClientService httpService)
        {
            _orderRepository = orderRepository;
            _httpService = httpService;
        }

        public long CreateOrder(List<ProductInCart> productInCarts, long clientAccountId, ShippingAddress shippingAddress)
        {
            try
            {
                var order = new Order() { ClientAccountId = clientAccountId , ShippingAddress = shippingAddress.ParseToJson() };
                var idOrder = _orderRepository.CreateOrder(order);
                foreach (var product in productInCarts)
                {
                    var orderInformation = new OrderInformation()
                    {
                        IdOrder = idOrder,
                        IdProduct = product.itemId,
                        Quantity = product.quantity
                    };
                    _orderRepository.CreateOrderInformation(orderInformation);
                }
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

            var requestUrl = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            var amount = 100000;
            var orderInfo = "Test";
            var notifyurl = "https://webhook.site/23c22149-0cd9-4108-8228-44b20a93b8f7";
            var extraData = "Test";
            string rawHash = "partnerCode=" +
                Constant.Payment.MoMo.PartnerCode + "&accessKey=" +
                Constant.Payment.MoMo.AccessCode + "&requestId=" +
                orderId + "&amount=" +
                amount + "&orderId=" +
                orderId + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            var signature = crypto.signSHA256(rawHash, Constant.Payment.MoMo.SecrectKey);
            if (string.IsNullOrWhiteSpace(signature))
            {
                return null;
            }

            HttpContext.Current.Session[Constant.SignatureSession] = signature;
            var paymentRequest = new MomoPaymentRequest()
            {
                AccessKey = Constant.Payment.MoMo.AccessCode,
                PartnerCode = Constant.Payment.MoMo.PartnerCode,
                RequestType = Constant.Payment.MoMo.RequestType,
                RequestId = orderId.ToString(),
                OrderId = orderId.ToString(),
                ReturnUrl = returnUrl,
                NotifyUrl = notifyurl,
                Amount = amount.ToString(),
                ExtraData = extraData,
                Signature = signature,
                OrderInfo = orderInfo
            };

            return _httpService.Post<MomoPaymentResponse>(requestUrl, paymentRequest);
        }
    }
}