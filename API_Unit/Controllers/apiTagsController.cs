using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Unit.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Unit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class apiTagsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetTagsList()
        {
            var result = new ObjectResult(_context.Tags);
            Request.HttpContext.Response.Headers.Add("x-count", _context.Tags.Count().ToString());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagsById([FromRoute] int id)
        {
            if (await _context.Tags.AnyAsync(x=>x.TagID==id))
            {
                return Ok(await _context.Tags.SingleOrDefaultAsync(t => t.TagID == id));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostTags([FromBody] Tags tags)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.Tags.AddAsync(tags);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTagsById", new { id = tags.TagID }, tags);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTags([FromRoute] int id, [FromBody] Tags tags)
        {
            _context.Entry(tags).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(tags);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTags([FromRoute] int id)
        {
            _context.Tags.Remove(await _context.Tags.FindAsync(id));
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
