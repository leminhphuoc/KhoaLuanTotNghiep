namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Room")]
    public partial class Room
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string DisplayName { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
    }
}
