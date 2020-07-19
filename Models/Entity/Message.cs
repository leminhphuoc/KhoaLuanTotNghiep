using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    [Table("Message")]
    public partial class Message
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Content { get; set; }

        public int OrderId { get; set; }

        public int AccountId { get; set; }
    }
}
