using Models.Entity;
using Models.Model;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface IOrderServices
    {
        long CreateOrder(List<ProductInCart> productInCarts, Customer customer);
    }
}
