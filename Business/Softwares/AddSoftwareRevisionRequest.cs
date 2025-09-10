using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Softwares
{
    public class AddSoftwareRevisionRequest
    {
        public int SoftwareId { get; set; }      
        public int Name { get; set; }      
        public string ApprovalCode { get; set; } 
        public string Notes { get; set; }        
        public IFormFile File { get; set; }     
    }
}
