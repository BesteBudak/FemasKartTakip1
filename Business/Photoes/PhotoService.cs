//using Business.Photoes;
//using Business.Responses;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;

//public class PhotoService : IPhotoService
//{

//    //private readonly string _uploadFolder;

//    //public PhotoService(string webRootPath)
//    //{
//    //    _uploadFolder = Path.Combine(webRootPath, "uploads");
//    //    if (!Directory.Exists(_uploadFolder))
//    //    {
//    //        Directory.CreateDirectory(_uploadFolder);
//    //    }
//    //}
//    private readonly string _uploadFolder;

//    public PhotoService(IConfiguration configuration)
//    {
//        _uploadFolder = configuration["PhotoSettings:UploadPath"];
//    }
//    public async Task<PhotoUploadResponse> UploadBase64Async(string base64)
//    {
//        if (string.IsNullOrWhiteSpace(base64))
//        {
//            return new PhotoUploadResponse
//            {
//                Success = false,
//                ErrorMessage = "Base64 string is empty."
//            };
//        }

//        try
//        {
//            var base64Data = base64;

//            // Data URI varsa ayıkla
//            if (base64.Contains(","))
//            {
//                base64Data = base64.Substring(base64.IndexOf(",") + 1);
//            }

//            var bytes = Convert.FromBase64String(base64Data);
//            var fileName = Guid.NewGuid().ToString() + ".jpg";
//            var filePath = Path.Combine(_uploadFolder, fileName);

//            await File.WriteAllBytesAsync(filePath, bytes);

//            var imageUrl = $"/uploads/{fileName}";

//            return new PhotoUploadResponse
//            {
//                Success = true,
//                Url = imageUrl
//            };
//        }
//        catch (Exception ex)
//        {
//            return new PhotoUploadResponse
//            {
//                Success = false,
//                ErrorMessage = $"Upload failed: {ex.Message}"
//            };
//        }
//    }

//    public async Task<bool> DeleteAsync(string imageUrl)
//    {
//        if (string.IsNullOrWhiteSpace(imageUrl))
//            return false;

//        try
//        {
//            var fileName = Path.GetFileName(imageUrl);
//            var filePath = Path.Combine(_uploadFolder, fileName);

//            if (File.Exists(filePath))
//            {
//                File.Delete(filePath);
//                return true;
//            }

//            return false;
//        }
//        catch
//        {
//            return false;
//        }
//    }
//}
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Business.Photoes
{
    public class PhotoService : IPhotoService
    {
        private readonly string _uploadPath;

        public PhotoService(IOptions<PhotoSettings> options)
        {
            _uploadPath = options.Value.UploadPath;
        }

        public async Task<(bool Success, string Url)> UploadBase64Async(string base64)
        {
            // Burada fotoğrafı _uploadPath içine kaydedebilirsin.
            // Şimdilik dummy return:
            await Task.CompletedTask;
            return (true, $"{_uploadPath}/dummy.jpg");
        }
    }
}
