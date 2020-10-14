using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IStaffAdminRepository
    {
        Staff GetDetail(long id);
        List<Staff> GetListStaff();
        bool? ChangeStatus(long id);
        long AddStaff(Staff staff);
        bool EditStaff(Staff staff);
        bool Delete(long id);
        List<Staff> ListSearchStaff(string searchString);
        bool CheckExits(string name);
        bool? ShowOnHome(long id);
    }
}
