using Business;
using Business.Requests;
using Business.Users;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllListAsync();
            return Ok(result);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            if (request == null)
                return BadRequest("Geçersiz veri.");

            var result = await _userService.CreateAsync(request);
            return CreatedAtAction(nameof(GetAll), new { id = result.Data.Id }, result);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
        {
            if (request == null)
                return BadRequest("Geçersiz veri.");

            var result = await _userService.UpdateAsync(id, request);
            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result);
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result);
        }
    }
}
