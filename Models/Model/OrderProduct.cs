using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class OrderProduct
    {
        public OrderProduct(long productId, int quantity)
        {
            var product = new ProductAdminRepository().GetDetail(productId);
            Id = product.id;
            ProductName = product.name;
            Quantity = quantity;
            Price = product.price;
            TotalPrice = Price * quantity;
            ProductImage = product.image;
        }
        public long Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public string ProductImage { get; set; }
    }
}
