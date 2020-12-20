using Models.Entity;
using Models.Model;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly IOrderRepository _orderRepository;
        public MembershipService(IClientAccountRepository clientAccountRepository, IOrderRepository orderRepository)
        {
            _clientAccountRepository = clientAccountRepository;
            _orderRepository = orderRepository;
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

            return result;
        }

        public ClientAccount Login(string email, string passWord)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(passWord))
            {
                return null;
            }

            return _clientAccountRepository.GetClientAccounts().FirstOrDefault(x => (x.Email.Equals(email) && x.PassWord.Equals(passWord)));
        }
    }
}