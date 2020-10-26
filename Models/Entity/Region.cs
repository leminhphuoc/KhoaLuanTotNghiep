namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Region")]
    public partial class Region
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public long DistrictId { get; set; }
    }
}
