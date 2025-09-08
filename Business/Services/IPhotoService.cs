using Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IPhotoService
    {
        Task<PhotoUploadResponse> UploadBase64Async(string base64);
        Task<bool> DeleteAsync(string imageUrl);
    }

  
}

