namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Content")]
    public partial class Content
    {
        public long id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(100)]
        public string metatitle { get; set; }

        [StringLength(500)]
        public string MetaKeyWord { get; set; }

        [StringLength(500)]
        public string MetaDescription { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [StringLength(250)]
        public string image { get; set; }

        public long? categoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createdDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifiedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? topHot { get; set; }

        public int? viewCount { get; set; }

        public bool? status { get; set; }
        public bool IsDisplayInHomePage { get; set; }
    }
}
