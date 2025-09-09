using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CardField
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public string Name { get; set; } // "Field1", "Field2", "Field3"
       
        public List<string> PhotoUrls { get; set; } = new();
    }

}
