using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class CartProduct
    {
        public CartProduct(long productId)
        {
            var product = new ProductAdminRepository().GetDetail(productId);
            ProductName = product.name;
            ProductPrice = product.promotionPrice != null ? product.promotionPrice.Value : product.price.Value;
            ProductImage = product.image == null ? "" : product.image;
        }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int Count { get; set; }
    }
}
