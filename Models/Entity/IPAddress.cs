namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IPAddress")]
    public partial class IPAddress
    {
        public long Id { get; set; }

        public string IP { get; set; }

        public DateTime date { get; set; }
    }
}
