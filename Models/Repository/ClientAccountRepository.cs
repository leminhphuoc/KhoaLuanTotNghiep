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
                _db.SaveChanges();
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
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at edit function from {nameof(BenefitRepository)}: {e.Message}");
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
                log.Error($"Error at Get Customer Account function from {nameof(ClientAccountRepository)}: {e.Message}");
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
                log.Error($"Error at Get Benefits {nameof(ClientAccountRepository)}: {e.Message}");
                return new List<ClientAccount>();
            }
        }
    }
}
