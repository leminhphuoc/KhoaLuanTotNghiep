namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Footer")]
    public partial class Footer
    {
        public int id { get; set; }

        [StringLength(50)]
        public string text { get; set; }

        [StringLength(100)]
        public string link { get; set; }

        public int? displayOrder { get; set; }

        public int? typeId { get; set; }

        public bool? status { get; set; }

        public string Icon { get; set; }
    }
}
