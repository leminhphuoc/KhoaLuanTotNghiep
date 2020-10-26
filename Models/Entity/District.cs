namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("District")]
    public partial class District
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
