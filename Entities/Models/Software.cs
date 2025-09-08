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
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string FarmwareCode { get; set; } //Yazılım kodu üsttekiyle birleşip atanmış yazılım oluyor kart tablosunda
        public ApprovalProcess ApprovalProcess { get; set; }
        public ICollection<Card> Cards { get; set; }
        
        public ICollection<SoftwareRevision> SoftwareRevisions { get; set; }
        public string ApprovalCode { get; set; }//revizyon no
        public string FileType { get; set; }
        public bool Status { get; set; }
    }
}
