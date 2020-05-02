namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Banner")]
    public partial class Banner
    {
        public int Id { get; set; }
        public int Location { get; set; }
        [StringLength(500)]
        public string Image { get; set; } 
    }
}
