namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public partial class Product
    {
        public long id { get; set; }

        [Required]
        [StringLength(250)]
        public string name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [StringLength(999)]
        public string description { get; set; }

        public string image { get; set; }

        [Column(TypeName = "xml")]
        public string moreImages { get; set; }

        public decimal? price { get; set; }

        public decimal? promotionPrice { get; set; }

        [Required]
        public int? idCategory { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createdDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifiDate { get; set; }

        public bool? status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? topHot { get; set; }

        public bool isDisplayHomePage { get; set; }

        public int AmountSold { get; set; }
    }
}
