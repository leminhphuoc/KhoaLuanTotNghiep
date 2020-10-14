namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ContentCategory")]
    public partial class ContentCategory
    {
        public long id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(250)]
        public string metatitle { get; set; }

        public int? parentID { get; set; }

        public int? displayOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createdDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifiedDate { get; set; }

        public bool? status { get; set; }

        public bool? showOnHome { get; set; }
    }
}
