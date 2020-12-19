namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order")]
    public partial class Order
    {
        public long Id { get; set; }

        public long ClientAccountId { get; set; }

        public int IdStatus { get; set; }

        public string PaymentMethod { get; set; }

        public string ShippingAddress { get; set; }

        public decimal SubTotal { get; set; }
        public string CouponCode { get; set; }

        public decimal Discount { get; set; }

        public decimal GrandTotal { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? createdDate { get; set; }
    }
}
