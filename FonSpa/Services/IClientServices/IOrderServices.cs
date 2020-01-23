using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonNature.Services.IClientServices
{
    public interface IOrderServices
    {
        long CreateOrder(List<OrderInformation> orderInformations, Customer customer)
    }
}
