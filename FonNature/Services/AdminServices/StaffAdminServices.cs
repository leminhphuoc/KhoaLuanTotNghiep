using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;

namespace FonNature.Services.Services
{
    public class StaffAdminServices : IStaffAdminServices
    {
        private readonly IStaffAdminRepository _staffAdminRepository;
        public StaffAdminServices(IStaffAdminRepository staffAdminRepository)
        {
            _staffAdminRepository = staffAdminRepository;
        }

        public List<Staff> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _staffAdminRepository.GetListStaff();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListStaff = _staffAdminRepository.ListSearchStaff(searchString);
                return ListStaff;
            }
        }

        public long AddStaff(Staff staff)
        {
            if (staff == null) return 0;
            var addStaff = _staffAdminRepository.AddStaff(staff);
            var idStaff = addStaff;
            return idStaff;
        }

        public Staff GetDetail(int id)
        {
            if (id == 0) return null;
            var staff = _staffAdminRepository.GetDetail(id);
            return staff;
        }

        public bool Edit(Staff staff)
        {
            if (staff == null) return false;
            var editStaff = _staffAdminRepository.EditStaff(staff);
            return editStaff;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _staffAdminRepository.Delete(id);
            return deleteSuccess;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _staffAdminRepository.ChangeStatus(id);
            return status;
        }

        public bool? ShowOnHome(int id)
        {
            var showStatus = _staffAdminRepository.ShowOnHome(id);
            return showStatus;
        }
    }
}