using Models.Entity;
using Models.Model;

namespace FonNature.Services
{
    public interface IMembershipService
    {
        ClientAccount Login(string email, string passWord);
        MemberProfileViewModel GetMemberProfileViewModel(long id);
    }
}
