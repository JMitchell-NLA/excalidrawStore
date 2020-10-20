using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using excalidrawCloud.Data;
using excalidrawCloud.Models;
using Microsoft.AspNetCore.Cors;

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
        [EnableCors("AnotherPolicy")]
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
        // GET: api/Excalidraw/names
        [EnableCors("AnotherPolicy")]
        [HttpGet("names")]
        public async Task<ActionResult<IEnumerable<CloudDocInfo>>> GetExcalidrawInfos()
        {
            var excalidraws = await _context.Excalidraws.ToListAsync();
            return excalidraws.Select(s => { return new CloudDocInfo(s.ID,s.name,s.lastSaved);}).ToList<CloudDocInfo>();
            // AND THATS HOW YOU MAP A F***ing list MOFO's 

            // C# really do let you keep things very condensed; It's a language that's much easier
            // To read than it is to write. 
            // Time to write it better on the other side.
        }


        // PUT: api/Excalidraw/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExcalidraw(int id, Excalidraw excalidraw)
        {
            Excalidraw og = _context.Excalidraws.AsNoTracking().ToList().First(s => s.ID == id);
            
            // Return a bad request if the ID is invalid, or if the date of document being 
            // put is earlier than the one currently being stored there. 
            if (id != excalidraw.ID && (excalidraw.lastSaved.CompareTo(og.lastSaved) < 0 ))
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
        [EnableCors("AnotherPolicy")]
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
