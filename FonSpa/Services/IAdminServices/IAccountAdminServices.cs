using FonNature.Areas.Admin.Models;
using Models.Entity;

namespace FonNature.Services.IServices
{
    public interface IAccountAdminServices
    {
        int checkLoginAdmin(LoginModel loginModel);
        bool CreateAccount(AccountAdmin accountAdmin);
        bool EditAccount(AccountAdmin accountAdmin);
    }
}
