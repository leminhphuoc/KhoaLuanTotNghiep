using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Cart
    {
        public List<ProductInCart> productInCarts { get; set; }
        public Customer customer { get; set; }
    }
}
