using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
