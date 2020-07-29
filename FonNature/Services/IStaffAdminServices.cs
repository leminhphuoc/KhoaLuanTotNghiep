using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface IStaffAdminServices
    {
        List<Staff> ListAllByName(string searchString);
        long AddStaff(Staff staff);
        bool Delete(int id);
        Staff GetDetail(int id);
        bool Edit(Staff staff);
        bool? ChangeStatus(int id);
        bool? ShowOnHome(int id);
    }
}
