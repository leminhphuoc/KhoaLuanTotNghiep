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
        public long Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
        /// <summary>
        /// 1: About, 2: Testimonial
        /// </summary>
        public int Category { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
    }
}
