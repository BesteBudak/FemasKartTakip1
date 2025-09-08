using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests
{
    public class UpdateApprovalStatusRequest
    {
        public int ApprovalId { get; set; }
        public ApprovalStatus NewStatus { get; set; }
    }

}
