using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CardId")]
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int Total { get; set; }
        public bool Status { get; set; }
        
    }
}
