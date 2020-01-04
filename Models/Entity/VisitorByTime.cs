namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorByTime")]
    public partial class VisitorByTime
    {
        public long Id { get; set; }

        public DateTime Time { get; set; }

        public long Count { get; set; }
    }
}
