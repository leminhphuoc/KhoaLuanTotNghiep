using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services.Services
{
    public class FooterAdminServices : IFooterAdminServices
    {
        private readonly IFooterAdminRepository _footerAdminRepository;
        public FooterAdminServices(IFooterAdminRepository footerAdminRepository)
        {
            _footerAdminRepository = footerAdminRepository;
        }

        public List<FooterCategory> GetFooterCategory()
        {
            return _footerAdminRepository.GetFooterCategories();
        }

        public List<Footer> GetListFooter()
        {
             return _footerAdminRepository.GetListFooter();
        }

        public long AddFooter(Footer footer)
        {
            if (footer == null) return 0;
            var addFooter = _footerAdminRepository.AddFooter(footer);
            var idFooter = addFooter;
            return idFooter;
        }

        public Footer GetDetail(int id)
        {
            if (id == 0) return null;
            var footer = _footerAdminRepository.GetDetail(id);
            return footer;
        }

        public bool Edit(Footer footer)
        {
            if (footer == null) return false;
            var editFooter = _footerAdminRepository.EditFooter(footer);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _footerAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _footerAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}