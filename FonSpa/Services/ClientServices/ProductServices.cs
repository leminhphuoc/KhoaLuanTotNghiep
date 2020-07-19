using FonNature.Enum;
using FonNature.Services.IClientServices;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FonNature.Services.ClientServices
{
    public class ProductServices : IProductServices
    {
        private readonly ProductAdminRepository _productAdminRepository;
        private readonly ProductCategoryAdminRepository _productCateAdminRepository;
        private readonly SEORepository _seoRepository;
        private readonly BannerRepository _bannerRepository;
        public ProductServices()
        {
            _productAdminRepository = ProductAdminRepository.getInstance();
            _seoRepository = SEORepository.getInstance();
            _productCateAdminRepository = ProductCategoryAdminRepository.getInstance();
            _bannerRepository = BannerRepository.getInstance();
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

        public List<Banner> GetProductBanner()
        {
            return _bannerRepository.GetList().Where(x => x.Location != (int)BannerLocation.Home).ToList();
        }

        public List<ProductCategory> GetProductCategories()
        {
            return _productCateAdminRepository.GetListProductCategory().ToList();
        }
    }
}