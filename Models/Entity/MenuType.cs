namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MenuType")]
    public partial class MenuType
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
