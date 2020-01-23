namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInformation")]
    public partial class OrderInformation
    {
        public long Id { get; set; }

        public long IdProduct { get; set; }

        public long IdOrder { get; set; }

        public int? IdStatus { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
