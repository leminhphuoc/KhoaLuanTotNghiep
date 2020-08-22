namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dictionary")]
    public partial class Dictionary
    {
        public long Id { get; set; }

        [StringLength(250)]
        public string Key { get; set; }

        [StringLength(250)]
        public string Value { get; set; }
    }
}
