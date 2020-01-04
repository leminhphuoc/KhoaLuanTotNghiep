namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int id { get; set; }

        [StringLength(50)]
        public string text { get; set; }

        [StringLength(100)]
        public string link { get; set; }

        public int? displayOrder { get; set; }

        public int? typeId { get; set; }

        public bool? status { get; set; }
    }
}
