using FonNature.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FonNature.Services.ClientServices
{
    public class ProductServices : IProductServices
    {
        private readonly IProductAdminRepository _productAdminRepository;
        private readonly IProductCategoryAdminRepository _productCateAdminRepository;
        private readonly ISEORepository _seoRepository;
        public ProductServices(IProductAdminRepository productAdminRepository , ISEORepository seoRepository, IProductCategoryAdminRepository productCateAdminRepository)
        {
            _productAdminRepository = productAdminRepository;
            _seoRepository = seoRepository;
            _productCateAdminRepository = productCateAdminRepository;
        }
        public SEO GetProductSeo()
        {
            return  _seoRepository.GetSEO(2);
        }

        public List<Product> ListAll()
        {
            return _productAdminRepository.GetListProduct().Where(x=>x.status == true).OrderBy(x=>x.createdDate).ToList();
        }

        public List<Product> ListByCategory(int idCategory)
        {
            return _productAdminRepository.GetListProduct().Where(x => x.status == true && x.idCategory == idCategory).OrderBy(x => x.createdDate).ToList();
        }

        public Product GetDetail(long id)
        {
            if (id == 0) return null;
            return _productAdminRepository.GetDetail(id);
        }

        public List<string> GetImagesList(long id)
        {
            if (id == 0) return new List<string>();
            var imageInDb = _productAdminRepository.GetImagesList(id);
            if (imageInDb == null) return new List<string>();
            var imageXML = XElement.Parse(imageInDb);
            var imagesList = new List<string>();
            foreach (var node in imageXML.Elements())
            {
                imagesList.Add(node.Value);
            }
            return imagesList;
        }

        public string GetCategoryName(long categoryId)
        {
            var categoryList = _productCateAdminRepository.GetListProductCategory();
            var result = categoryList.SingleOrDefault(x => x.id == categoryId);
            return result.name;
        }

        public List<Product> GetRelatedProduct(Product product)
        {
            var productList = _productAdminRepository.GetListProduct();
            var result = productList.Where(x => x.id != product.id && x.idCategory == product.idCategory).ToList();
            return result;
        }

    }
}