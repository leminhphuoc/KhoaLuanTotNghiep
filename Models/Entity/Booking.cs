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
        [Range(1, int.MaxValue, ErrorMessage = "Please select arrival time!")]
        public int PeriodTime{ get; set; }

        [Required]
        public long ClientAccountId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select service!")]
        public long ServiceId { get; set; }

        public int RoomId { get; set; }

        public int Duration { get; set; }

        [StringLength(2000)]
        public string Message { get; set; }

        public int Quantity { get; set; }

        public bool IsCancel { get; set; }
    }
}