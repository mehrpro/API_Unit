using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Unit;
using API_Unit.Models;

namespace API_Unit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagRegisteredsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TagRegisteredsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TagRegistereds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagRegistered>>> GetTagRegistereds()
        {
            return await _context.TagRegistereds.ToListAsync();
        }

        // GET: api/TagRegistereds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagRegistered>> GetTagRegistered(long id)
        {
            var tagRegistered = await _context.TagRegistereds.FindAsync(id);

            if (tagRegistered == null)
            {
                return NotFound();
            }

            return tagRegistered;
        }

        // PUT: api/TagRegistereds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagRegistered(long id, TagRegistered tagRegistered)
        {
            if (id != tagRegistered.RowID)
            {
                return BadRequest();
            }

            _context.Entry(tagRegistered).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagRegisteredExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TagRegistereds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagRegistered>> PostTagRegistered(TagRegistered tagRegistered)
        {
            _context.TagRegistereds.Add(tagRegistered);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagRegistered", new { id = tagRegistered.RowID }, tagRegistered);
        }

        // DELETE: api/TagRegistereds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagRegistered(long id)
        {
            var tagRegistered = await _context.TagRegistereds.FindAsync(id);
            if (tagRegistered == null)
            {
                return NotFound();
            }

            _context.TagRegistereds.Remove(tagRegistered);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagRegisteredExists(long id)
        {
            return _context.TagRegistereds.Any(e => e.RowID == id);
        }
    }
}
