using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IClientServices
{
    public interface IProductServices
    {
        List<Product> ListAll();
        Product GetDetail(long id);
        List<Product> ListByCategory(int idCategory);
        SEO GetProductSeo();
        List<string> GetImagesList(long id);
    }
}
