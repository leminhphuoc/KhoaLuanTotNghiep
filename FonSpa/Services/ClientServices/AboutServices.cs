using FonNature.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services.ClientServices
{
    public class AboutServices: IAboutServices
    {
        private readonly IAboutAdminRepository _aboutAdminRepository;
        private readonly IStaffAdminRepository _staffAdminRepository;
        public AboutServices(IAboutAdminRepository aboutAdminRepository, IStaffAdminRepository staffAdminRepository)
        {
            _aboutAdminRepository = aboutAdminRepository;
            _staffAdminRepository = staffAdminRepository;
        }

        public About GetAbout(int id)
        {
            if (id == 0) return null;
            return _aboutAdminRepository.GetDetail(id);
        }

        public List<About> GetAbouts()
        {
            return _aboutAdminRepository.GetListAbout().Where(x=>x.status == true).OrderBy(x=>x.id).ToList();
        }

        public List<Staff> GetStaffs()
        {
            return _staffAdminRepository.GetListStaff().Where(x => x.status == true && x.ShowOnHome == true).OrderBy(x => x.createdDate).Take(3).ToList();
        }

    }
}