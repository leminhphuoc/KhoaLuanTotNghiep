using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;

namespace FonNature.Services.Services
{
    public class ProductCategoryAdminService : IProductCategoryAdminServices
    {
        private readonly ProductCategoryAdminRepository _productCategoryAdminRepository;
        public ProductCategoryAdminService()
        {
            _productCategoryAdminRepository = ProductCategoryAdminRepository.getInstance();
        }

        public List<ProductCategory> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _productCategoryAdminRepository.GetListProductCategory();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListProductCategory = _productCategoryAdminRepository.ListSearchProductCategory(searchString);
                return ListProductCategory;
            }
        }

        public List<ProductCategory> GetProductCategory()
        {
            return _productCategoryAdminRepository.GetListProductCategory();
        }

        public long AddProductCategory(ProductCategory productcategory)
        {
            if (productcategory == null) return 0;
            var addProductCategory = _productCategoryAdminRepository.AddProductCategory(productcategory);
            var idProductCategory = addProductCategory;
            return idProductCategory;
        }

        public ProductCategory GetDetail(int id)
        {
            if (id == 0) return null;
            var productcategory = _productCategoryAdminRepository.GetDetail(id);
            return productcategory;
        }

        public bool Edit(ProductCategory productcategory)
        {
            if (productcategory == null) return false;
            var editProductCategory = _productCategoryAdminRepository.EditProductCategory(productcategory);
            return editProductCategory;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _productCategoryAdminRepository.Delete(id);
            return deleteSuccess;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _productCategoryAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}