namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public long id { get; set; }

        [StringLength(250)]
        public string name { get; set; }
        /// <summary>
        /// 1: About, 2: Testimonial
        /// </summary>
        public int Category { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        public string description { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        [StringLength(250)]
        public string image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createdDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifiedDate { get; set; }

        public bool? status { get; set; }
    }
}
