using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses
{
    public class ApprovalResponse
    {
        public int ApprovalId { get; set; }        // ApprovalProcess ID
        public int CardId { get; set; }            // Card ID
        public string CardStockCode { get; set; }  // Kart Stok Kodu
        public string CardName { get; set; }       // Kart Tanımı
        public string SoftwareCode { get; set; }   // Yazılım Kodu
        public string SoftwareName { get; set; }   // Yazılım Tanımı
        public string ProgramType { get; set; }    // Program Tipi
        public string Status { get; set; }         // Onaylandı / Reddedildi
        public string Uploader { get; set; }
    }

}
