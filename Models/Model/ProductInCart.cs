using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class ProductInCart
    {
        public long itemId { get; set; }
        public int quantity { get; set; }
    }
}
