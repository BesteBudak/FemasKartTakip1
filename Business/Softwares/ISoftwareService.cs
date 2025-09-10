using Business.Requests;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Softwares
{
    public interface ISoftwareService
    {
        Task<ServiceResult<SoftwareResponse>> GetByIdAsync(int id);
        Task<ServiceResult<List<SoftwareResponse>>> GetAllAsync();
        Task<ServiceResult<SoftwareResponse>> CreateAsync(CreateSoftwareRequest request);
        Task<ServiceResult<SoftwareResponse>> UpdateAsync(int id, UpdateSoftwareRequest request);
        Task<ServiceResult<bool>> DeleteAsync(int id);

        Task<ServiceResult<SoftwareRevisionResponse>> AddRevisionAsync(AddSoftwareRevisionRequest request);
    }


}
