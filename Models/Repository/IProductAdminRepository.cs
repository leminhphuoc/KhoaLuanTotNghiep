using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IProductAdminRepository
    {
        Product GetDetail(long id);
        List<Product> GetListProduct();
        bool? ChangeStatus(long id);
        long AddProduct(Product product);
        bool EditProduct(Product product);
        bool Delete(long id);
        List<Product> ListSearchProduct(string searchString);
        List<ProductCategory> GetProductCategories();
        bool CheckExits(string name);
        bool SaveImages(string images, long id);
        string GetImagesList(long id);
    }
}
