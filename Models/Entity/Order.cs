namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order")]
    public partial class Order
    {
        public long Id { get; set; }

        public long IdCustomer { get; set; }

        public int IdStatus { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? createdDate { get; set; }
    }
}
