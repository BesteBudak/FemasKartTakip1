using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests
{
    public class CreateCardRequest
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string StockCode { get; set; }
        public string SupplierCode { get; set; }
       
        public string ApprovalCode { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }

        public List<List<string>> FieldPhotos { get; set; }
    }


}
