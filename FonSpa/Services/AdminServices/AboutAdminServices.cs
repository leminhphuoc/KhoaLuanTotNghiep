using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;

namespace FonNature.Services.Services
{
    public class AboutAdminServices : IAboutAdminServices
    {
        private readonly AboutAdminRepository _aboutAdminRepository;
        public AboutAdminServices()
        {
            _aboutAdminRepository = AboutAdminRepository.getInstance();
        }

        public List<About> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _aboutAdminRepository.GetListAbout();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListAbout = _aboutAdminRepository.ListSearchAbout(searchString);
                return ListAbout;
            }
        }

        public long AddAbout(About about)
        {
            if (about == null) return 0;
            var addAbout = _aboutAdminRepository.AddAbout(about);
            var idAbout = addAbout;
            return idAbout;
        }

        public About GetDetail(int id)
        {
            if (id == 0) return null;
            var about = _aboutAdminRepository.GetDetail(id);
            return about;
        }

        public bool Edit(About about)
        {
            if (about == null) return false;
            var editAbout = _aboutAdminRepository.EditAbout(about);
            return editAbout;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _aboutAdminRepository.Delete(id);
            return deleteSuccess;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _aboutAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}