namespace Models.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CouponCode")]
    public partial class CouponCode
    {
        [Key]
        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(100)]
        public string DisplayName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public decimal DiscountValue { get; set; }

        public string ProductId { get; set; }
    }
}
