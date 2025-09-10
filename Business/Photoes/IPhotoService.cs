using Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Photoes
{
    public interface IPhotoService
    {
        //Task<PhotoUploadResponse> UploadBase64Async(string base64);
        //Task<bool> DeleteAsync(string imageUrl);
        Task<(bool Success, string Url)> UploadBase64Async(string base64);
    }

  
}

