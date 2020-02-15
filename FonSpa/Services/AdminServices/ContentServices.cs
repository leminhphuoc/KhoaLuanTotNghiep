using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;

namespace FonNature.Services.Services
{
    public class ContentServices : IContentServices
    {
        private readonly IContentAdminRepository _contentAdminRepository;
        public ContentServices(IContentAdminRepository contentAdminRepository)
        {
            _contentAdminRepository = contentAdminRepository;
        }

        public Content GetDetail(long id)
        {
            if (id == 0) return null;
            var content = _contentAdminRepository.GetDetail(id);
            return content;
        }

        public List<Content> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _contentAdminRepository.GetListContent();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var listContent = _contentAdminRepository.ListSearchContent(searchString);
                return listContent;
            }
        }

        public List<ContentCategory> GetContentCategory()
        {
            return _contentAdminRepository.GetContentCategories(); 
        }

        public long AddContent(Content content)
        {
            if (content == null) return 0;
            var addContent = _contentAdminRepository.AddContent(content);
            var idContent = addContent;
            return idContent;
        }

        public bool EditContent(Content content)
        {
            if (content == null) return false;
            var editSuccess = _contentAdminRepository.EditContent(content);
            if (!editSuccess) return false;
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            _contentAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            if (id == 0) return false;
            var status = _contentAdminRepository.ChangeStatus(id);
            return status;
        }

    }
}