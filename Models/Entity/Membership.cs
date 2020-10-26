namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Membership")]
    public partial class Membership
    {
        public long Id { get; set; }
    }
}

