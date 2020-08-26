using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface IProductCategoryAdminServices
    {
        List<ProductCategory> ListAllByName(string searchString);
        List<ProductCategory> GetProductCategory();
        long AddProductCategory(ProductCategory productcategory);
        bool Delete(int id);
        ProductCategory GetDetail(int id);
        bool Edit(ProductCategory productcategory);
        bool? ChangeStatus(int id);
    }
}