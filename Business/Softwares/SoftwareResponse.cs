using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Softwares
{
    public class SoftwareResponse
    {
        public int Id { get; set; }
        public string FarmwareCode { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string ApprovalCode { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } 
    }
}
