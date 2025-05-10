using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly Context _context;

        public TypeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemType>>> GetAll()
        {
            return await _context.ItemType.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemType>> GetById(Guid id)
        {
            var type = await _context.ItemType.FindAsync(id);
            if (type == null) return NotFound();
            return type;
        }

        [HttpPost]
        public async Task<ActionResult<ItemType>> Create(ItemType type)
        {
            _context.ItemType.Add(type);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = type.Id }, type);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ItemType type)
        {
            if (id != type.Id) return BadRequest();

            _context.Entry(type).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var type = await _context.ItemType.FindAsync(id);
            if (type == null) return NotFound();

            _context.ItemType.Remove(type);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
