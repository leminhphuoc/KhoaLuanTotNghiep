using Models.Entity;
using Models.Model;

namespace FonNature.Services
{
    public interface IMembershipService
    {
        ClientAccount Login(string email, string passWord);
        MemberProfileViewModel GetMemberProfileViewModel(long id);
        long Register(string firstName, string lastName, string email, string mobilePhone, string passWord);
    }
}
