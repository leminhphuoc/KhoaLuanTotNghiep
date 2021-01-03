using FonNature.Authentication;
using Models.Entity;
using Models.Model;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FonNature.Services.Extension;
using HelperLibrary;
using System.Web.Mvc;

namespace FonNature.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBookingRepository _bookingRepository;
        private const string  Password = "]bc5M>[M}ym>[4a=";
        public MembershipService(IClientAccountRepository clientAccountRepository, IOrderRepository orderRepository, IBookingRepository bookingRepository)
        {
            _clientAccountRepository = clientAccountRepository;
            _orderRepository = orderRepository;
            _bookingRepository = bookingRepository;
        }

        public MemberProfileViewModel GetMemberProfileViewModel(long id)
        {
            if(id == 0)
            {
                return null;
            }

            var clientAccount = _clientAccountRepository.GetClientAccount(id);
            if(clientAccount == null)
            {
                return null;
            }

            var result = new MemberProfileViewModel()
            {
                AccountInformation = clientAccount
            };

            var allOrders = _orderRepository.GetOrders();
            if(allOrders == null || !allOrders.Any())
            {
                return result;
            }

            result.Orders = allOrders.Where(x => x.ClientAccountId.Equals(id)).ToList();

            var allBookings = _bookingRepository.GetBookings();
            if (allBookings == null || !allBookings.Any())
            {
                return result;
            }

            result.Bookings = allBookings.Where(x => x.ClientAccountId.Equals(id)).ToList();

            return result;
        }

        public ClientAccount Login(string email, string passWord)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(passWord))
            {
                return null;
            }

            var encryptedPassword = Cipher.Encrypt(passWord, Password);

            return _clientAccountRepository.GetClientAccounts().FirstOrDefault(x => (x.Email.Equals(email) && x.PassWord.Equals(encryptedPassword)));
        }

        public long Register(string firstName, string lastName, string email, string mobilePhone, string passWord)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(passWord))
            {
                return 0;
            }

            var encryptedPassword = Cipher.Encrypt(passWord, Password);
            var token = StringExtension.GenerateToken();
            token = token.RemoveSpecialCharacters();

            var account = new ClientAccount()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                MobilePhone = mobilePhone,
                PassWord = encryptedPassword,
                Token = token
            };

            var accountId = _clientAccountRepository.Add(account);

            try
            {
                var sendMailUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/membership/confirm" + "?token=" + token + "&email=" + email;
                var mailContent = System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Asset/Client/Mail/ConfirmRegister.html"));
                mailContent = mailContent.Replace("{{url}}", sendMailUrl);
                new MailHelper().SendMail(email, "Verification Email from Fon Spa", mailContent);
            }
            catch(Exception ex)
            {
                return accountId;
            }
            

            return accountId;
        }
    }
}