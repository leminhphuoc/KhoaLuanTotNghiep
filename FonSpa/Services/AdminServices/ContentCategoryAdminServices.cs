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
    public class ContentCategoryAdminServices : IContentCategoryAdminServices
    {
        private readonly IContentCategoryAdminRepository _contentCategoryAdminRepository;
        public ContentCategoryAdminServices(IContentCategoryAdminRepository contentCategoryAdminRepository)
        {
            _contentCategoryAdminRepository = contentCategoryAdminRepository;
        }

        public List<ContentCategory> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _contentCategoryAdminRepository.GetListContentCategory();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListContentCategory = _contentCategoryAdminRepository.ListSearchContentCategory(searchString);
                return ListContentCategory;
            }
        }

        public List<ContentCategory> GetContentCategory()
        {
            return _contentCategoryAdminRepository.GetListContentCategory();
        }

        public long AddContentCategory(ContentCategory contentategory)
        {
            if (contentategory == null) return 0;
            var addContentCategory = _contentCategoryAdminRepository.AddContentCategory(contentategory);
            var idContentCategory = addContentCategory;
            return idContentCategory;
        }

        public ContentCategory GetDetail(int id)
        {
            if (id == 0) return null;
            var contentcategory = _contentCategoryAdminRepository.GetDetail(id);
            return contentcategory;
        }

        public bool Edit(ContentCategory contentcategory)
        {
            if (contentcategory == null) return false;
            var editProductCategory = _contentCategoryAdminRepository.EditContentCategory(contentcategory);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _contentCategoryAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _contentCategoryAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}