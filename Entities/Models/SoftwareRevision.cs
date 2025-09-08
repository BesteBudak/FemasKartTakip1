using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SoftwareRevision
    {
        [Key]
        public int Id { get; set; }
        public Software Software { get; set; }
        public int SoftwareId { get; set; }
        public string FileType { get; set; }
        public string Uploader { get; set; }
        public string ApprovalCode { get; set; }
        public string Notes { get; set; }
        public string FilePath { get; set; }
    }
}
