namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ClientAccount")]
    public partial class ClientAccount
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string MobilePhone { get; set; }

        [Required]
        [StringLength(1000)]
        public string PassWord { get; set; }

        public long TitleId { get; set; }

        [StringLength(100)]
        public string NickName { get; set; }

        public long MaritalStatusId { get; set; }

        public long AgeRangeId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime Birth { get; set; }

        public long GenderId { get; set; }

        public long RegionId { get; set; }

        public long OccupationId { get; set; }

        /// <summary>
        /// True : Active, False : Inactive
        /// </summary>
        public bool Status { get; set; }
    }
}

