namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FooterCategory")]
    public partial class FooterCategory
    {
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }
    }
}
