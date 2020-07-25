using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IServices
{
    public interface IProductAdminSerivces
    {
        List<Product> ListAllByName(string searchString);
        List<ProductCategory> GetProductCategory();
        long AddProduct(Product product);
        bool Delete(int id);
        Product GetDetail(int id);
        bool Edit(Product product);
        bool? ChangeStatus(int id);
        bool SaveProductImage(string images, long id);
        List<string> GetImagesList(long id);
    }
}
