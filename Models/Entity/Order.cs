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

        [Column(TypeName = "datetime")]
        public DateTime? createdDate { get; set; }
    }
}
