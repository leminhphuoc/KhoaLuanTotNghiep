namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MaritalStatusCustomer")]
    public partial class MaritalStatusCustomer
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}

