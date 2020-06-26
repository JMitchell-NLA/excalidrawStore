using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using excalidrawCloud.Data;
using excalidrawCloud.Models;

namespace excalidrawCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcalidrawController : ControllerBase
    {
        private readonly ExcalidrawContext _context;

        public ExcalidrawController(ExcalidrawContext context)
        {
            _context = context;
        }

        // GET: api/Excalidraw
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Excalidraw>>> GetExcalidraws()
        {
            return await _context.Excalidraws.ToListAsync();
        }

        // GET: api/Excalidraw/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Excalidraw>> GetExcalidraw(int id)
        {
            var excalidraw = await _context.Excalidraws.FindAsync(id);

            if (excalidraw == null)
            {
                return NotFound();
            }

            return excalidraw;
        }

        // PUT: api/Excalidraw/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExcalidraw(int id, Excalidraw excalidraw)
        {
            if (id != excalidraw.ID)
            {
                return BadRequest();
            }

            _context.Entry(excalidraw).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcalidrawExists(id))
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

        // POST: api/Excalidraw
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Excalidraw>> PostExcalidraw(Excalidraw excalidraw)
        {
            _context.Excalidraws.Add(excalidraw);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExcalidraw", new { id = excalidraw.ID }, excalidraw);
        }

        // DELETE: api/Excalidraw/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Excalidraw>> DeleteExcalidraw(int id)
        {
            var excalidraw = await _context.Excalidraws.FindAsync(id);
            if (excalidraw == null)
            {
                return NotFound();
            }

            _context.Excalidraws.Remove(excalidraw);
            await _context.SaveChangesAsync();

            return excalidraw;
        }

        private bool ExcalidrawExists(int id)
        {
            return _context.Excalidraws.Any(e => e.ID == id);
        }
    }
}
