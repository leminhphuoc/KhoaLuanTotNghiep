namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GenderCustomer")]
    public partial class GenderCustomer
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
