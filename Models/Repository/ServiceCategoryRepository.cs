using log4net;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ServiceCategoryRepository()
        {
            _db = new FonNatureDbContext();
        }

        public List<ServiceCategory> GetServiceCategories()
        {
            try
            {
                var categories = _db.ServiceCategories;
                if (categories == null)
                {
                    log.Error($"{nameof(GetServiceCategories)} result is null");
                    return new List<ServiceCategory>();
                }

                log.Info($"{nameof(GetServiceCategories)} result is {categories}");

                return categories.ToList();
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetServiceCategories)}: {ex.Message}");
                return new List<ServiceCategory>();
            }
        }

        public List<ServiceCategory> SearchServiceCategory(string searchString)
        {
            try
            {
                var categories = _db.ServiceCategories.Where(x => x.Name.ToLower().Contains(searchString.ToLower()));
                if (categories == null)
                {
                    log.Error($"{nameof(SearchServiceCategory)} result is null");
                    return new List<ServiceCategory>();
                }

                log.Info($"{nameof(SearchServiceCategory)} result is {categories}");

                return categories.ToList();
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(SearchServiceCategory)}: {ex.Message}");
                return new List<ServiceCategory>();
            }
        }

        public ServiceCategory GetServiceCategory(long id)
        {
            try
            {
                var category = _db.ServiceCategories.Find(id);
                if (category == null)
                {
                    log.Error($"{nameof(GetServiceCategory)} result is null or don't have item");
                    return null;
                }

                log.Info($"{nameof(GetServiceCategory)} result is {category}");

                return category;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetServiceCategory)}: {ex.Message}");
                return null;
            }
        }

        public ServiceCategory AddServiceCategory(ServiceCategory serviceCategory)
        {
            try
            {
                serviceCategory.CreatedDate = DateTime.Now;
                var addedCategory = _db.ServiceCategories.Add(serviceCategory);
                _db.SaveChanges();

                if (addedCategory == null)
                {
                    log.Error($"{nameof(AddServiceCategory)} return null");
                    return null;
                }

                log.Info($"{nameof(AddServiceCategory)} result is {addedCategory}");

                return addedCategory;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(AddServiceCategory)}: {ex.Message}");
                return null;
            }
        }

        public long EditServiceCategory(ServiceCategory serviceCategory)
        {
            try
            {
                var updateServiceCategory = _db.ServiceCategories.Find(serviceCategory.Id);
                if (updateServiceCategory == null)
                {
                    log.Error($"{nameof(EditServiceCategory)} cannot find dictionary with id {serviceCategory.Id}");
                    return 0;
                }

                updateServiceCategory.Name = serviceCategory.Name;
                updateServiceCategory.Metatitle = serviceCategory.Metatitle;
                updateServiceCategory.ShowOnHome = serviceCategory.ShowOnHome;
                updateServiceCategory.DisplayOrder = serviceCategory.DisplayOrder;
                updateServiceCategory.Status = serviceCategory.Status;
                updateServiceCategory.ParentID = serviceCategory.ParentID;
                updateServiceCategory.ModifiedDate = DateTime.Now;
                _db.SaveChanges();

                log.Info($"{nameof(EditServiceCategory)} success with Name : {updateServiceCategory.Name}");

                return updateServiceCategory.Id;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(EditServiceCategory)}: {ex.Message}");
                return 0;
            }
        }

        public bool RemoveServiceCategory(long id)
        {
            try
            {
                var removeServiceCategory = _db.ServiceCategories.Find(id);
                if (removeServiceCategory == null)
                {
                    log.Error($"{nameof(RemoveServiceCategory)} cannot find dictionary with id {id}");
                    return false;
                }

                _db.ServiceCategories.Remove(removeServiceCategory);
                _db.SaveChanges();

                log.Info($"{nameof(RemoveServiceCategory)} success with id : {removeServiceCategory.Id}");

                return true;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(RemoveServiceCategory)}: {ex.Message}");
                return false;
            }
        }
    }
}
