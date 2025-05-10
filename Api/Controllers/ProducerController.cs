using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly Context _context;

        public ProducerController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producer>>> GetAll()
        {
            return await _context.Producer.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producer>> GetById(Guid id)
        {
            var producer = await _context.Producer.FindAsync(id);
            if (producer == null) return NotFound();
            return producer;
        }

        [HttpPost]
        public async Task<ActionResult<Producer>> Create(Producer producer)
        {
            _context.Producer.Add(producer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = producer.Id }, producer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Producer producer)
        {
            if (id != producer.Id) return BadRequest();

            _context.Entry(producer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var producer = await _context.Producer.FindAsync(id);
            if (producer == null) return NotFound();

            _context.Producer.Remove(producer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
