using HelperLibrary;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;

namespace FonNature.Services
{
    public class FooterCategoryAdminServices : IFooterCategoryAdminServices
    {
        private readonly IFooterCategoryAdminRepository _footerCategoryAdminRepository;
        public FooterCategoryAdminServices(IFooterCategoryAdminRepository footerCategoryAdminRepository)
        {
            _footerCategoryAdminRepository = footerCategoryAdminRepository;
        }

        public List<FooterCategory> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _footerCategoryAdminRepository.GetListFooterCategory();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListFooterCategory = _footerCategoryAdminRepository.ListSearchFooterCategory(searchString);
                return ListFooterCategory;
            }
        }

        public List<FooterCategory> GetFooterCategory()
        {
            return _footerCategoryAdminRepository.GetListFooterCategory();
        }

        public long AddFooterCategory(FooterCategory footercategory)
        {
            if (footercategory == null) return 0;
            var addFooterCategory = _footerCategoryAdminRepository.AddFooterCategory(footercategory);
            var idFooterCategory = addFooterCategory;
            return idFooterCategory;
        }

        public FooterCategory GetDetail(int id)
        {
            if (id == 0) return null;
            var footercategory = _footerCategoryAdminRepository.GetDetail(id);
            return footercategory;
        }

        public bool Edit(FooterCategory footercategory)
        {
            if (footercategory == null) return false;
            var editFooterCategory = _footerCategoryAdminRepository.EditFooterCategory(footercategory);
            return editFooterCategory;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _footerCategoryAdminRepository.Delete(id);
            return deleteSuccess;
        }
    }
}