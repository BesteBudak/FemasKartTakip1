using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string StockCode { get; set; }
        public string SupplierCode { get; set; } //tedarikçi kodu
       

        public ICollection<Software> Softwares { get; set; }
        public int SoftwareId { get; set; }
        public string ApprovalCode { get; set; } //revizyon no
        public ICollection<CardField> Fields { get; set; } = new List<CardField>();

        public string Type { get; set; }
        public bool Status { get; set; }
    }
}
