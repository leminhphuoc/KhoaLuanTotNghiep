namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int id { get; set; }

        [Column(TypeName = "ntext")]
        public string content { get; set; }

        public bool? status { get; set; }
    }
}
