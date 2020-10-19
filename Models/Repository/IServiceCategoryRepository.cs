using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface IServiceCategoryRepository
    {
        List<ServiceCategory> GetServiceCategories();
        List<ServiceCategory> SearchServiceCategory(string searchString);
        ServiceCategory GetServiceCategory(long id);
        ServiceCategory AddServiceCategory(ServiceCategory service);
        long EditServiceCategory(ServiceCategory service);
        bool RemoveServiceCategory(long id);
    }
}
