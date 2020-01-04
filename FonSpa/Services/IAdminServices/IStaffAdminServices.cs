using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonNature.Services.IServices
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
