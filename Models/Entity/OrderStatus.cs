namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderStatus")]
    public partial class OrderStatus
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
    }
}
