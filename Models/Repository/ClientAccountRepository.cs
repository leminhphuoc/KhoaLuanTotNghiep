using log4net;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class ClientAccountRepository : IClientAccountRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ClientAccountRepository()
        {
            _db = new FonNatureDbContext();
        }

        public long Add(ClientAccount account)
        {
            try
            {
                if(account == null)
                {
                    return 0;
                }

                account.CreatedDate = DateTime.Now;
                var addedItem = _db.ClientAccounts.Add(account);
                Db.SaveChanges();
                return addedItem.Id;
            }
            catch (Exception e)
            {
                log.Error($"Error at add function from {nameof(ClientAccountRepository)}: {e.Message}");
                return 0;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var account = _db.ClientAccounts.Find(id);
                _db.ClientAccounts.Remove(account);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at delete function {nameof(ClientAccountRepository)}: {e.Message}");
                return false;
            }
        }

        public bool Edit(ClientAccount account)
        {
            try
            {
                var editAccount = _db.ClientAccounts.Find(account.Id);
                editAccount.AgeRangeId = account.AgeRangeId;
                editAccount.Birth = account.Birth;
                editAccount.FirstName = account.FirstName;
                editAccount.GenderId = account.GenderId;
                editAccount.LastName = account.LastName;
                editAccount.MaritalStatusId = account.MaritalStatusId;
                editAccount.NickName = account.NickName;
                editAccount.OccupationId = account.OccupationId;
                editAccount.RegionId = account.RegionId;
                editAccount.TitleId = account.TitleId;
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at edit function from {nameof(ClientAccountRepository)}: {e.Message}");
                return false;
            }
        }

        public ClientAccount GetClientAccount(long id)
        {
            try
            {
                var account = _db.ClientAccounts.Find(id);
                return account;
            }
            catch (Exception e)
            {
                log.Error($"Error at GetClientAccount function from {nameof(ClientAccountRepository)}: {e.Message}");
                return null;
            }
        }

        public List<ClientAccount> GetClientAccounts()
        {
            try
            {
                return _db.ClientAccounts.ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at GetClientAccounts {nameof(ClientAccountRepository)}: {e.Message}");
                return new List<ClientAccount>();
            }
        }

        public bool UpdateProfile(long clientAccountId, string newpwd, string firstName, string lastName)
        {
            if(string.IsNullOrWhiteSpace(newpwd) || clientAccountId == 0)
            {
                return false;
            }
            try
            {
                var accountUpdated = _db.ClientAccounts.Find(clientAccountId);
                if(accountUpdated == null)
                {
                    log.Error($"Cannot find account when update profile {nameof(ClientAccountRepository)}");
                    return false;
                }

                accountUpdated.PassWord = newpwd;
                accountUpdated.FirstName = firstName;
                accountUpdated.LastName = lastName;
                _db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at UpdatePassword {nameof(ClientAccountRepository)}: {e.Message}");
                return false;
            }
        }

        public List<ClientAccount> SearchClient(string searchString)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(searchString))
                {
                    return new List<ClientAccount>();
                }

                return _db.ClientAccounts.Where(x=> x.MobilePhone.Contains(searchString)).ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at SearchClient {nameof(ClientAccountRepository)}: {e.Message}");
                return new List<ClientAccount>();
            }
        }

        public ClientAccount GetClientByPhone(string mobilePhone)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mobilePhone))
                {
                    return null;
                }

                return _db.ClientAccounts.FirstOrDefault(x => x.MobilePhone.Equals(mobilePhone));
            }
            catch (Exception e)
            {
                log.Error($"Error at GetClientByPhone {nameof(ClientAccountRepository)}: {e.Message}");
                return null;
            }
        }

        public long AddPremember(ClientAccount account)
        {
            try
            {
                if(account == null)
                {
                    log.Error($"Error at AddPremember function from {nameof(ClientAccountRepository)}: account is null");
                    return 0;
                }

                account.IsPreMember = true;
                account.CreatedDate = DateTime.Now;
                var addedItem = _db.ClientAccounts.Add(account);
                Db.SaveChanges();
                return addedItem.Id;
            }
            catch (Exception e)
            {
                log.Error($"Error at add function from {nameof(ClientAccountRepository)}: {e.Message}");
                return 0;
            }
        }

        public bool IsExistMobilePhone(string mobilePhone)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(mobilePhone))
                {
                    return false;
                }

                return _db.ClientAccounts.Any(x => !x.IsPreMember && x.MobilePhone.Equals(mobilePhone));
            }
            catch (Exception e)
            {
                log.Error($"Error at IsExistMobilePhone from {nameof(ClientAccountRepository)}: {e.Message}");
                return false;
            }
        }

        public bool IsExistEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return false;
                }

                return _db.ClientAccounts.Any(x => !x.IsPreMember && x.Email.Equals(email));
            }
            catch (Exception e)
            {
                log.Error($"Error at IsExistEmail from {nameof(ClientAccountRepository)}: {e.Message}");
                return false;
            }
        }

        public ClientAccount ConfirmAccountByTokenAndEmail(string email, string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                {
                    return null;
                }

                var account =  _db.ClientAccounts.FirstOrDefault(x => x.Token.Equals(token) && x.Email.Equals(email));
                if(account == null)
                {
                    return null;
                }

                account.IsConfirm = true;
                _db.SaveChanges();

                return account;
            }
            catch (Exception e)
            {
                log.Error($"Error at GetAccountByTokenAndEmail from {nameof(ClientAccountRepository)}: {e.Message}");
                return null;
            }
        }
    }
}
