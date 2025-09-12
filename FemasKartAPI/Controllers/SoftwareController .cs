using Business.Requests;
using Business.Softwares;
using FemasKart.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FemasKartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly ISoftwareService _softwareService;

        public SoftwareController(ISoftwareService softwareService)
        {
            _softwareService = softwareService;
        }

        // GET: api/software
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _softwareService.GetAllAsync();
            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        // GET: api/software/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _softwareService.GetByIdAsync(id);
            if (!result.IsSuccess) return NotFound(result.ErrorMessage);

            return Ok(result.Data);
        }

        // POST: api/software
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSoftwareRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _softwareService.CreateAsync(request);
            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        // PUT: api/software/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSoftwareRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _softwareService.UpdateAsync(id, request);
            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }

        // DELETE: api/software/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _softwareService.DeleteAsync(id);
            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

            return NoContent(); // 204
        }

        // POST: api/software/add-revision
        [HttpPost("add-revision")]
        public async Task<IActionResult> AddRevision([FromBody] AddSoftwareRevisionViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var request = new AddSoftwareRevisionRequest
            {
                SoftwareId = model.SoftwareId,
                ApprovalCode = "REV-" + model.RevisionNo,
                Notes = model.Notes,
                File = model.File
            };

            var result = await _softwareService.AddRevisionAsync(request);
            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

            return Ok(result.Data);
        }
    }
}
