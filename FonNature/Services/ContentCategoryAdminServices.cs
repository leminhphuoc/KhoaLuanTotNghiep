using HelperLibrary;
using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;

namespace FonNature.Services
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

        public long AddContentCategory(ContentCategory contentCategory)
        {
            if (contentCategory == null) return 0;
            var addContentCategory = _contentCategoryAdminRepository.AddContentCategory(contentCategory);
            var idContentCategory = addContentCategory;
            return idContentCategory;
        }

        public ContentCategory GetDetail(int id)
        {
            if (id == 0) return null;
            var contentcategory = _contentCategoryAdminRepository.GetDetail(id);
            return contentcategory;
        }

        public bool Edit(ContentCategory contentCategory)
        {
            if (contentCategory == null) return false;
            var editProductCategory = _contentCategoryAdminRepository.EditContentCategory(contentCategory);
            return editProductCategory;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _contentCategoryAdminRepository.Delete(id);
            return deleteSuccess;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _contentCategoryAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}