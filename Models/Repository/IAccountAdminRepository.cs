using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface IAccountAdminRepository
    {
        AccountAdmin GetDetail(long id);
        List<AccountAdmin> GetListAccount();
        bool? ChangeStatus(long id);
        bool CheckUserName(string userName);
        bool CheckPassword(string userName, string password);
        long AddAccount(AccountAdmin accountAdmin);
        bool EditAccount(AccountAdmin accountAdmin);
        bool Delete(long id);
        bool CheckStatusAccount(string userName, string password);
    }
}
