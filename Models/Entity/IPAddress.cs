namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IPAddress")]
    public partial class IPAddress
    {
        public long Id { get; set; }

        public string IP { get; set; }

        public DateTime date { get; set; }
    }
}
