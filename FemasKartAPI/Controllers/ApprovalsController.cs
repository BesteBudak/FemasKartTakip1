using Business.ApprovalProcesses;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalsController : ControllerBase
    {
        private readonly IApprovalService _approvalService;

        public ApprovalsController(IApprovalService approvalService)
        {
            _approvalService = approvalService;
        }

       
        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            var approvals = await _approvalService.GetAllAsync();
            var filtered = approvals.Where(a => a.Status == "Bekliyor").ToList();
            return Ok(filtered);
        }

       
        [HttpGet("approved")]
        public async Task<IActionResult> GetApproved()
        {
            var approvals = await _approvalService.GetAllAsync();
            var filtered = approvals.Where(a => a.Status == "Onaylandı").ToList();
            return Ok(filtered);
        }

        [HttpGet("rejected")]
        public async Task<IActionResult> GetRejected()
        {
            var approvals = await _approvalService.GetAllAsync();
            var filtered = approvals.Where(a => a.Status == "Reddedildi").ToList();
            return Ok(filtered);
        }

       
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var request = new UpdateApprovalStatusRequest
            {
                ApprovalId = id,
                NewStatus = ApprovalStatus.Approved
            };

            var result = await _approvalService.UpdateStatusAsync(request);

            if (!result)
                return NotFound("Onay süreci bulunamadı.");

            return Ok("Kart başarıyla onaylandı.");
        }

        
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            var request = new UpdateApprovalStatusRequest
            {
                ApprovalId = id,
                NewStatus = ApprovalStatus.Rejected
            };

            var result = await _approvalService.UpdateStatusAsync(request);

            if (!result)
                return NotFound("Onay süreci bulunamadı.");

            return Ok("Kart reddedildi.");
        }
    }
}
