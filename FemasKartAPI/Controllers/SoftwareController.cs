//using Business.Requests;
//using Business.Softwares;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace WebApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SoftwareController : ControllerBase
//    {
//        private readonly ISoftwareService _softwareService;

//        public SoftwareController(ISoftwareService softwareService)
//        {
//            _softwareService = softwareService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var result = await _softwareService.GetAllAsync();
//            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

//            return Ok(result.Data); // JSON olarak döner
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateSoftwareRequest request)
//        {
//            var result = await _softwareService.CreateAsync(request);
//            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

//            return Ok();
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, [FromBody] UpdateSoftwareRequest request)
//        {
//            var result = await _softwareService.UpdateAsync(id, request);
//            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

//            return Ok();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var result = await _softwareService.DeleteAsync(id);
//            if (!result.IsSuccess) return BadRequest(result.ErrorMessage);

//            return Ok();
//        }
//    }
//}




using DataAccess;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FemasKart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SoftwareController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Softwares.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software == null) return NotFound();
            return Ok(software);
        }
       
      

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Software model)
        {
            if (!ModelState.IsValid) return BadRequest("Model invalid");
            _context.Softwares.Add(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] Software model)
        {
            if (!ModelState.IsValid) return BadRequest("Model invalid");
            var software = await _context.Softwares.FindAsync(model.Id);
            if (software == null) return NotFound();

            software.Name = model.Name;
            software.Description = model.Description;
            software.FarmwareCode = model.FarmwareCode;
            software.ApprovalCode = model.ApprovalCode;
            software.FileType = model.FileType;
            software.Status = model.Status;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software == null) return NotFound();

            _context.Softwares.Remove(software);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
