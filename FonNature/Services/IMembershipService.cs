using Models.Entity;

namespace FonNature.Services
{
    public interface IMembershipService
    {
        ClientAccount Login(string email, string passWord);
    }
}
