using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public long AddProduct(Product product)
        {
            product.status = false;
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
            productEdit.description = product.description;
            productEdit.image = product.image;
            productEdit.moreImages = product.moreImages;
            productEdit.price = product.price;
            productEdit.promotionPrice = product.promotionPrice;
            productEdit.quantity = product.quantity;
            productEdit.idCategory = product.idCategory;
            productEdit.detail = product.detail;
            productEdit.modifiDate = DateTime.Now;
            productEdit.status = product.status;
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

            var listProduct = _db.Products.Where(x => x.name.ToUpper() == searchString.ToUpper());
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


    }
}
