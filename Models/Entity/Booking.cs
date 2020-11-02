namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public long Id { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        public long ClientAccountId { get; set; }

        [Required]
        public long ServiceId { get; set; }

        public int RoomId { get; set; }

        [StringLength(2000)]
        public string Message { get; set; }
    }
}