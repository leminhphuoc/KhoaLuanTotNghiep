namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TitleCustomer")]
    public partial class TitleCustomer
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
