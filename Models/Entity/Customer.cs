namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        public string phone { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        [StringLength(100)]
        public string token { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createdDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifiedDate { get; set; }

        public bool? status { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
