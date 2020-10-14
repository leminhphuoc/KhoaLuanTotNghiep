using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class StaffAdminRepository : IStaffAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public StaffAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Staff GetDetail(long id)
        {
            var staff = _db.Staffs.Find(id);
            return staff;
        }

        public List<Staff> GetListStaff()
        {
            return _db.Staffs.ToList();
        }

        public long AddStaff(Staff staff)
        {
            staff.createdDate = DateTime.Now;
            var addStaff = _db.Staffs.Add(staff);
            _db.SaveChanges();
            return addStaff.Id;
        }

        public bool EditStaff(Staff staff)
        {
            var staffEdit = _db.Staffs.Where(x => x.Id == staff.Id).SingleOrDefault();
            staffEdit.Name = staff.Name;
            staffEdit.Email = staff.Email;
            staffEdit.Phone = staff.Phone;
            staffEdit.Address = staff.Address;
            staffEdit.modifiedDate = DateTime.Now;
            staffEdit.status = staff.status;
            staffEdit.IdAccount = staff.IdAccount;
            staffEdit.ShowOnHome = staff.ShowOnHome;
            staffEdit.Position = staff.Position;
            staffEdit.image = staff.image;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var staff = _db.Staffs.Find(id);
            if (staff != null)
            {
                _db.Staffs.Remove(staff);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Staffs.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public bool? ShowOnHome(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Staffs.Find(id);
            accountNeedChange.ShowOnHome = !accountNeedChange.ShowOnHome;
            _db.SaveChanges();
            return accountNeedChange.ShowOnHome;
        }

        public List<Staff> ListSearchStaff(string searchString)
        {
            if (searchString == null) return null;

            var listStaff = _db.Staffs.Where(x => x.Name.ToUpper() == searchString.ToUpper());
            return listStaff.ToList();
        }

        public bool CheckExits(string name)
        {
            var staff = _db.Staffs.Where(x => x.Name == name).SingleOrDefault();
            if (staff != null) return true;
            return false;
        }
    }
}
