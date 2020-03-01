using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Models.Repository
{
    public class ProductAdminRepository : IProductAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public ProductAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Product GetDetail(long id)
        {
            var product = _db.Products.Find(id);
            return product;
        }

        public List<Product> GetListProduct()
        {
            return _db.Products.ToList();
        }

        public bool SaveImages(string images, long id)
        {
            var product = _db.Products.Find(id);
            product.moreImages = images;
            _db.SaveChanges();
            return true;
        }
        public string GetImagesList(long id)
        {
            var imageInDb = _db.Products.Find(id);
            if (imageInDb == null) return null;
            return imageInDb.moreImages;
        }

        public long AddProduct(Product product)
        {
            product.createdDate = DateTime.Now;
            var addProduct = _db.Products.Add(product);
            _db.SaveChanges();
            return addProduct.id;
        }

        public bool EditProduct(Product product)
        {
            var productEdit = _db.Products.Where(x => x.id == product.id).SingleOrDefault();
            productEdit.name = product.name;
            productEdit.metaTitle = product.metaTitle;
            productEdit.MetaKeyword = product.metaTitle;
            productEdit.MetaDescription = product.metaTitle;
            productEdit.description = product.description;
            productEdit.image = product.image;
            productEdit.moreImages = product.moreImages;
            productEdit.price = product.price;
            productEdit.promotionPrice = product.promotionPrice;
            productEdit.quantity = product.quantity;
            productEdit.idCategory = product.idCategory;
            productEdit.detail = product.detail;
            productEdit.modifiDate = DateTime.Now;
            productEdit.status = true;
            productEdit.topHot = product.topHot;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Products.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<Product> ListSearchProduct(string searchString)
        {
            if (searchString == null) return null;

            var listProduct = _db.Products.Where(Predicate(searchString));
            return listProduct.ToList();
        }

        public bool CheckExits(string name)
        {
            var product = _db.Products.Where(x => x.name == name).SingleOrDefault();
            if (product != null) return true;
            return false;
        }

        public List<ProductCategory> GetProductCategories()
        {
            return _db.ProductCategories.ToList();
        }

        public int Count()
        {
            return _db.Products.Count();
        }

        private static Func<Product, bool> Predicate(string searchString)
        {
            return x => Helper.RemoveSign4VietnameseString(x.name).ToUpper().Contains(searchString.ToUpper());
        }
    }
}
