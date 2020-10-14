namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderInformation")]
    public partial class OrderInformation
    {
        public long Id { get; set; }

        public long IdProduct { get; set; }

        public long IdOrder { get; set; }

        public int Quantity { get; set; }
    }
}
