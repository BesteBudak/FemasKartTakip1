namespace FemasKart.ViewModels
{
    public class AddSoftwareRevisionViewModel
    {
        public int SoftwareId { get; set; }
        public string SoftwareName { get; set; }   // sadece ekranda göstermek için
        public int RevisionNo { get; set; }
        public string? Notes { get; set; }         // isteğe bağlı açıklama
        public IFormFile? File { get; set; }       // .bat veya .hex dosyası
    }
}
