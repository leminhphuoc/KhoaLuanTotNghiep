namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [StringLength(250)]
        public string image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createdDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifiedDate { get; set; }

        public bool? status { get; set; }

        public bool? ShowOnHome { get; set; }

        public long IdAccount { get; set; }
    }
}
