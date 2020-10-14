using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IProductCategoryAdminRepository
    {
        ProductCategory GetDetail(long id);
        List<ProductCategory> GetListProductCategory();
        bool? ChangeStatus(long id);
        long AddProductCategory(ProductCategory productcategory);
        bool EditProductCategory(ProductCategory productcategory);
        bool Delete(long id);
        List<ProductCategory> ListSearchProductCategory(string searchString);
        bool CheckExits(string name);
    }
}
