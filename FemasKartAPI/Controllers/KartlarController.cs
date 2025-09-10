using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FemasKartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KartlarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KartlarController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Kartlar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetKartlar()
        {
            return await _context.Cards.ToListAsync();
        }

        //// POST: api/Kartlar
        //[HttpPost]
        //public async Task<ActionResult<Card>> PostKart(Card card)
        //{
        //    _context.Cards.Add(card);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetKartlar), new { id = card.Id }, card);
        //}

        //// PUT: api/Kartlar/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutKart(int id, Card card)
        //{
        //    if (id != card.Id)
        //        return BadRequest();

        //    var existing = await _context.Cards.FindAsync(id);
        //    if (existing == null)
        //        return NotFound();

        //    // Güncellenecek alanlar
        //    existing.Name = card.Name;
        //    existing.Brand = card.Brand;
        //    existing.StockCode = card.StockCode;
        //    existing.SoftwareId = card.SoftwareId;
        //    existing.ApprovalCode = card.ApprovalCode;
        //    existing.Type = card.Type;
        //    existing.Status = card.Status;

        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //// DELETE: api/Kartlar/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteKart(int id)
        //{
        //    var card = await _context.Cards.FindAsync(id);
        //    if (card == null)
        //        return NotFound();

        //    _context.Cards.Remove(card);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}
