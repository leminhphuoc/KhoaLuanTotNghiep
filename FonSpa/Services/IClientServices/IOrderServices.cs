using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IClientServices
{
    public interface IOrderServices
    {
        long CreateOrder(List<OrderInformation> orderInformations, Customer customer);
    }
}
