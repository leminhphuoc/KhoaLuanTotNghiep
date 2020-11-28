using Models.Entity;
using System.Collections.Generic;

namespace Models.Model
{
    public class Cart
    {
        public List<ProductInCart> productInCarts { get; set; }
        public ClientAccount customer { get; set; }
    }
}
