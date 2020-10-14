using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class ProductCategoryAdminRepository : IProductCategoryAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public ProductCategoryAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public ProductCategory GetDetail(long id)
        {
            var productcategory = _db.ProductCategories.Find(id);
            return productcategory;
        }

        public List<ProductCategory> GetListProductCategory()
        {
            return _db.ProductCategories.ToList();
        }

        public long AddProductCategory(ProductCategory productcategory)
        {
            productcategory.status = false;
            productcategory.createdDate = DateTime.Now;
            var addProductCategory = _db.ProductCategories.Add(productcategory);
            _db.SaveChanges();
            return addProductCategory.id;
        }

        public bool EditProductCategory(ProductCategory productcategory)
        {
            var productcategoryEdit = _db.ProductCategories.Where(x => x.id == productcategory.id).SingleOrDefault();
            productcategoryEdit.name = productcategory.name;
            productcategoryEdit.metatitle = productcategory.metatitle;
            productcategoryEdit.parentID = productcategory.parentID;
            productcategoryEdit.displayOrder = productcategory.displayOrder;
            productcategoryEdit.modifiedDate = DateTime.Now;
            productcategoryEdit.status = productcategory.status;
            productcategoryEdit.showOnHome = productcategory.showOnHome;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var productcategory = _db.ProductCategories.Find(id);
            if (productcategory != null)
            {
                _db.ProductCategories.Remove(productcategory);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.ProductCategories.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<ProductCategory> ListSearchProductCategory(string searchString)
        {
            if (searchString == null) return null;

            var listProductCategory = _db.ProductCategories.Where(x => x.name.ToUpper() == searchString.ToUpper());
            return listProductCategory.ToList();
        }

        public bool CheckExits(string name)
        {
            var productcategory = _db.ProductCategories.Where(x => x.name == name).SingleOrDefault();
            if (productcategory != null) return true;
            return false;
        }

    }
}
