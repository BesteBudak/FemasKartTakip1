using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses
{
    public class CardFieldResponse
    {
        public string Name { get; set; } // Field1, Field2, Field3
        public List<string> PhotoUrls { get; set; }
    }
}
