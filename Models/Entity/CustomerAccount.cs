namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CustomerAccount")]
    public partial class CustomerAccount
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string userName { get; set; }

        [Required]
        [StringLength(100)]
        public string passWord { get; set; }

        public bool? type { get; set; }

        public bool? STATUS { get; set; }

        public long? IdCustomer { get; set; }
    }
}
