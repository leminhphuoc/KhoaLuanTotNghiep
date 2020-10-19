using log4net;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ServiceRepository()
        {
            _db = new FonNatureDbContext();
        }

        public List<Service> GetServices()
        {
            try
            {
                var servicess = _db.Services;
                if (servicess == null)
                {
                    log.Error($"{nameof(GetServices)} result is null");
                    return new List<Service>();
                }

                log.Info($"{nameof(GetServices)} result is {servicess}");

                return servicess.ToList();
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetServices)}: {ex.Message}");
                return new List<Service>();
            }
        }

        public List<Service> SearchService(string searchString)
        {
            try
            {
                var services = _db.Services.Where(x => x.Name.ToLower().Contains(searchString.ToLower()));
                if (services == null)
                {
                    log.Error($"{nameof(SearchService)} result is null");
                    return new List<Service>();
                }

                log.Info($"{nameof(SearchService)} result is {services}");

                return services.ToList();
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(SearchService)}: {ex.Message}");
                return new List<Service>();
            }
        }

        public Service GetService(long id)
        {
            try
            {
                var service = _db.Services.Find(id);
                if (service == null)
                {
                    log.Error($"{nameof(GetService)} result is null or don't have item");
                    return null;
                }

                log.Info($"{nameof(GetService)} result is {service}");

                return service;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetService)}: {ex.Message}");
                return null;
            }
        }

        public Service AddService(Service service)
        {
            try
            {
                var addedService = _db.Services.Add(service);
                _db.SaveChanges();

                if (addedService == null)
                {
                    log.Error($"{nameof(AddService)} return null");
                    return null;
                }

                log.Info($"{nameof(AddService)} result is {addedService}");

                return addedService;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(AddService)}: {ex.Message}");
                return null;
            }
        }

        public long EditService(Service service)
        {
            try
            {
                var updateService = _db.Services.Find(service.Id);
                if (updateService == null)
                {
                    log.Error($"{nameof(EditService)} cannot find dictionary with id {service.Id}");
                    return 0;
                }

                updateService.Name = service.Name;
                updateService.MetaTitle = service.MetaTitle;
                updateService.MetaKeyword = service.MetaKeyword;
                updateService.MetaDescription = service.MetaDescription;
                updateService.Description = service.Description;
                updateService.Image = service.Image;
                updateService.MoreImages = service.MoreImages;
                updateService.Price = service.Price;
                updateService.PromotionPrice = service.PromotionPrice;
                updateService.IdCategory = service.IdCategory;
                updateService.Detail = service.Detail;
                updateService.ModifiDate = DateTime.Now;
                updateService.Status = true;
                updateService.TopHot = service.TopHot;
                updateService.IsDisplayHomePage = service.IsDisplayHomePage;
                _db.SaveChanges();

                log.Info($"{nameof(EditService)} success with Name : {updateService.Name}");

                return updateService.Id;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(EditService)}: {ex.Message}");
                return 0;
            }
        }

        public bool RemoveService(long id)
        {
            try
            {
                var removeService = _db.Services.Find(id);
                if (removeService == null)
                {
                    log.Error($"{nameof(RemoveService)} cannot find dictionary with id {id}");
                    return false;
                }

                _db.Services.Remove(removeService);
                _db.SaveChanges();

                log.Info($"{nameof(RemoveService)} success with id : {removeService.Id}");

                return true;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(RemoveService)}: {ex.Message}");
                return false;
            }
        }
    }
}
