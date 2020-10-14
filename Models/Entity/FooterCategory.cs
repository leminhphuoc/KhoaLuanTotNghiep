namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FooterCategory")]
    public partial class FooterCategory
    {
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }
    }
}
