namespace Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Slide")]
    public partial class Slide
    {
        public long id { get; set; }

        //[StringLength(250)]
        public string image { get; set; }

        public int? displayOrder { get; set; }

        //[StringLength(250)]
        public string link { get; set; }

        //[Column(TypeName = "date")]
        public DateTime? createdDate { get; set; }

        //[Column(TypeName = "date")]
        public DateTime? modifiedDate { get; set; }

        public bool? status { get; set; }

        //[StringLength(250)]
        public string YellowTitle { get; set; }

        //[StringLength(250)]
        public string title { get; set; }

        //[StringLength(250)]
        public string subtitle { get; set; }

        //[StringLength(250)]
        public string TextButton { get; set; }

        // 1 = home, 2 = other
        public int SlideType { get; set; }
    }
}
