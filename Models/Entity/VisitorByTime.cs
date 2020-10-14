namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VisitorByTime")]
    public partial class VisitorByTime
    {
        public long Id { get; set; }

        public DateTime Time { get; set; }

        public long Count { get; set; }
    }
}
