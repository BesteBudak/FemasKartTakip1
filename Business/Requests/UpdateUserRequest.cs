using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests
{
    public class UpdateUserRequest
    { public string Name {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status {  get; set; }
    }
}
