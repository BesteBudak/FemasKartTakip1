using Business.Photoes;
using Business.Responses;
using Microsoft.AspNetCore.Hosting;


public class PhotoService : IPhotoService
{
    
    private readonly string _uploadFolder;

    //public PhotoService(IWebHostEnvironment env) // ✅ DI çözebilir
    //{
    //    _uploadFolder = Path.Combine(env.WebRootPath, "uploads");

    //    if (!Directory.Exists(_uploadFolder))
    //    {
    //        Directory.CreateDirectory(_uploadFolder);
    //    }
    //}


    public async Task<PhotoUploadResponse> UploadBase64Async(string base64)
    {
        if (string.IsNullOrWhiteSpace(base64))
        {
            return new PhotoUploadResponse
            {
                Success = false,
                ErrorMessage = "Base64 string is empty."
            };
        }

        try
        {
            var base64Data = base64;

            // Data URI varsa ayıkla
            if (base64.Contains(","))
            {
                base64Data = base64.Substring(base64.IndexOf(",") + 1);
            }

            var bytes = Convert.FromBase64String(base64Data);
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var filePath = Path.Combine(_uploadFolder, fileName);

            await File.WriteAllBytesAsync(filePath, bytes);

            var imageUrl = $"/uploads/{fileName}";

            return new PhotoUploadResponse
            {
                Success = true,
                Url = imageUrl
            };
        }
        catch (Exception ex)
        {
            return new PhotoUploadResponse
            {
                Success = false,
                ErrorMessage = $"Upload failed: {ex.Message}"
            };
        }
    }

    public async Task<bool> DeleteAsync(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            return false;

        try
        {
            var fileName = Path.GetFileName(imageUrl);
            var filePath = Path.Combine(_uploadFolder, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }
}
