using FonNature.Areas.Admin.Models;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonNature.Services.IServices
{
    public interface IAccountAdminServices
    {
        int checkLoginAdmin(LoginModel loginModel);
        bool CreateAccount(AccountAdmin accountAdmin);
        bool EditAccount(AccountAdmin accountAdmin);
    }
}
