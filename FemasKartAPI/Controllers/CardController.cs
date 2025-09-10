using Business.Cards;
using Business.Photoes;
using Business.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/cards
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cardService.GetAllAsync();
            return Ok(result);
        }

        // GET: api/cards/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cardService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result);
        }

        // POST: api/cards
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardRequest request)
        {
            if (request == null)
                return BadRequest("Geçersiz veri.");

            var result = await _cardService.CreateAsync(request);
            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }

        // PUT: api/cards/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCardRequest request)
        {
            if (request == null)
                return BadRequest("Geçersiz veri.");

            var result = await _cardService.UpdateAsync(id, request);
            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result);
        }

        // DELETE: api/cards/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cardService.DeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result);
        }
    }
}
