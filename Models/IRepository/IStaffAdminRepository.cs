using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
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
