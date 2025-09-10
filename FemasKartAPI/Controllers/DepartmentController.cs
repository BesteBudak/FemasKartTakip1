using Business.Services;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET api/departments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _departmentService.GetByIdAsync(id);
            if (!result.IsSuccess) return NotFound(result.ErrorMessage);
            return Ok(result.Data);
        }

        // POST api/departments
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            if (department == null) return BadRequest("Geçersiz veri.");

            var result = await _departmentService.CreateAsync(department);
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data);
        }

        // PUT api/departments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Department department)
        {
            if (department == null || department.Id != id)
                return BadRequest("Geçersiz veri.");

            var result = await _departmentService.UpdateAsync(department);
            if (!result.IsSuccess) return NotFound(result.ErrorMessage);

            return Ok("Bölüm başarıyla güncellendi.");
        }

        // DELETE api/departments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _departmentService.DeleteAsync(id);
            if (!result.IsSuccess) return NotFound(result.ErrorMessage);

            return Ok("Bölüm başarıyla silindi.");
        }

        // POST api/departments/{departmentId}/users
        [HttpPost("{departmentId}/users")]
        public async Task<IActionResult> AddUser(int departmentId, [FromBody] User user)
        {
            if (user == null) return BadRequest("Geçersiz veri.");

            var result = await _departmentService.AddUserToDepartmentAsync(departmentId, user);
            if (!result.IsSuccess) return NotFound(result.ErrorMessage);

            return Ok("Kullanıcı başarıyla bölüme eklendi.");
        }

        // DELETE api/departments/{departmentId}/users/{userId}
        [HttpDelete("{departmentId}/users/{userId}")]
        public async Task<IActionResult> RemoveUser(int departmentId, int userId)
        {
            var result = await _departmentService.RemoveUserFromDepartmentAsync(departmentId, userId);
            if (!result.IsSuccess) return NotFound(result.ErrorMessage);

            return Ok("Kullanıcı başarıyla bölümden çıkarıldı.");
        }
    }
}
