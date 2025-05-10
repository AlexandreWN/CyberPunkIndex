using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubTypeController : ControllerBase
    {
        private readonly Context _context;

        public SubTypeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubType>>> GetAll()
        {
            return await _context.SubType
                .Include(s => s.ItemType)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubType>> GetById(Guid id)
        {
            var subtype = await _context.SubType.FindAsync(id);
            if (subtype == null) return NotFound();
            return subtype;
        }

        [HttpPost]
        public async Task<ActionResult<SubType>> Create(SubType subtype)
        {
            _context.SubType.Add(subtype);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = subtype.Id }, subtype);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, SubType subtype)
        {
            if (id != subtype.Id) return BadRequest();

            _context.Entry(subtype).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var subtype = await _context.SubType.FindAsync(id);
            if (subtype == null) return NotFound();

            _context.SubType.Remove(subtype);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
