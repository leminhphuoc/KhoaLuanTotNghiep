namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountAdmin")]
    public partial class AccountAdmin
    {
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string userName { get; set; }

        [Required]
        [StringLength(100)]
        public string passWord { get; set; }

        public bool? type { get; set; }

        public bool? STATUS { get; set; }
    }
}
