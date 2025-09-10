using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ApprovalProcess
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SoftwareId")]
        public int SoftwareId { get; set; }
        public Software Software { get; set; }
        public string Uploader {  get; set; }
        public ApprovalStatus Status { get; set; }
    }
    public enum ApprovalStatus
    {
        Pending = 0,    // Bekliyor
        Approved = 1,   // Onaylandı
        Rejected = 2    // Reddedildi
    }

}
