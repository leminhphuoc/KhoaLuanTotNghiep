namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SEO")]
    public partial class SEO
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string MetaKeyWord { get; set; }

        [StringLength(500)]
        public string MetaDescription { get; set; }

        public int TypeId { get; set; }
    }
}
