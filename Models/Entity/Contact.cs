namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contact")]
    public partial class Contact
    {
        public int id { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string MobilePhone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string LinkFaceBook { get; set; }

        [StringLength(250)]
        public string LinkInstagram { get; set; }

        [StringLength(250)]
        public string LogoHeader { get; set; }

        [StringLength(250)]
        public string LogoFooter { get; set; }

        [StringLength(1000)]
        public string FacebookPagePlugin { get; set; }
    }
}
