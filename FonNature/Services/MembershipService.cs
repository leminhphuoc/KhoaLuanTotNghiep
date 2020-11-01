using Models.Entity;
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
        public MembershipService(IClientAccountRepository clientAccountRepository)
        {
            _clientAccountRepository = clientAccountRepository;
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