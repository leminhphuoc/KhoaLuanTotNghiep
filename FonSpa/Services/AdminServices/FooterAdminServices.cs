using FonNature.Services.IServices;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;

namespace FonNature.Services.Services
{
    public class FooterAdminServices : IFooterAdminServices
    {
        private readonly FooterAdminRepository _footerAdminRepository;
        public FooterAdminServices()
        {
            _footerAdminRepository = FooterAdminRepository.getInstance();
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
            _footerAdminRepository.EditFooter(footer);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            _footerAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _footerAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}