using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses
{
    public class PhotoUploadResponse
    {
        public bool Success { get; set; }
        public string Url { get; set; }
        public string ErrorMessage { get; set; }
    }
}
