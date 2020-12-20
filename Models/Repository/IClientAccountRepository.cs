using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IClientAccountRepository
    {
        long Add(ClientAccount benefit);
        bool Delete(long id);
        bool Edit(ClientAccount benefit);
        ClientAccount GetClientAccount(long id);
        List<ClientAccount> GetClientAccounts();
        bool UpdateProfile(long clientAccountId, string newpwd, string firstName, string lastName);
    }
}
