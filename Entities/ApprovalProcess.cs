using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ApprovalProcess
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SoftwareId")]
        public int SoftwareId { get; set; }
        public Software Software { get; set; }
        public bool ApprovalStatus { get; set; }
    }
}
