namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AccountAdmin")]
    public partial class AccountAdmin
    {
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string userName { get; set; }

        [Required]
        [StringLength(100)]
        public string passWord { get; set; }

        public bool? type { get; set; }

        public bool? STATUS { get; set; }
    }
}
