using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FarmwareCode { get; set; } = string.Empty;
        public string ApprovalCode { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public bool Status {  get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
        public ICollection<SoftwareRevision> SoftwareRevisions { get; set; } = new List<SoftwareRevision>();
        public ApprovalProcess ApprovalProcess { get; set; } = new ApprovalProcess();

    }
}