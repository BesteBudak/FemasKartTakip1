namespace FemasKart.ViewModels
{
    public class SoftwareViewModel
    {
        public int Id { get; set; }
        public string SoftwareCode { get; set; }   // FarmwareCode
        public string Name { get; set; }           // Yazılım Adı
        public string Description { get; set; }
        public string ProgrammingType { get; set; } // FileType
        public int RevisionNo { get; set; }
    }
}
