namespace Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UsefulInformation")]
    public partial class UsefulInformation
    {
        public long Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int? Value { get; set; }
    }
}
