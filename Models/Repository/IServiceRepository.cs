using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface IServiceRepository
    {
        List<Service> GetServices();
        List<Service> SearchService(string searchString);
        Service GetService(long id);
        Service AddService(Service service);
        long EditService(Service service);
        bool RemoveService(long id);
    }
}
