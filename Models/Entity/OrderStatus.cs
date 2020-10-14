namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderStatus")]
    public partial class OrderStatus
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
    }
}
