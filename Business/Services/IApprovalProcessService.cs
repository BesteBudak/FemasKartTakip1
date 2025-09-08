using Business.Requests;
using Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IApprovalService
    {
        Task<List<ApprovalResponse>> GetAllAsync();
        Task<bool> UpdateStatusAsync(UpdateApprovalStatusRequest request);
    }

}
