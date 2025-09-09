using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ApprovalProcesses
{
    public interface IApprovalService
    {
        Task<List<ApprovalResponse>> GetAllAsync();
        Task<bool> UpdateStatusAsync(UpdateApprovalStatusRequest request);
    }

}
