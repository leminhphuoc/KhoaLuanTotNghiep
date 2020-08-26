namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Page")]
    public partial class Page
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        [Column(TypeName = "ntext")]
        public string Body { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(1000)]
        public string MetaDescription { get; set; }

        [StringLength(1000)]
        public string MetaKeywords { get; set; }
    }
}
