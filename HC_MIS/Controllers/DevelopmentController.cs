using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HC_MIS.Data;
using HC_MIS.Models;

namespace HC_MIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentController : ControllerBase
    {
        private readonly HC_DbContext _context;

        public DevelopmentController(HC_DbContext context)
        {
            _context = context;
        }

        // GET: api/Development
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hc_dev>>> Gethc_development()
        {
            return await _context.hc_development.ToListAsync();
        }

        // GET: api/Development/5
        [HttpGet("{id}")]
        public async Task<ActionResult<hc_dev>> Gethc_dev(int id)
        {
            var hc_dev = await _context.hc_development.FindAsync(id);

            if (hc_dev == null)
            {
                return NotFound();
            }

            return hc_dev;
        }

        // PUT: api/Development/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthc_dev(int id, hc_dev hc_dev)
        {
            if (id != hc_dev.Id)
            {
                return BadRequest();
            }

            _context.Entry(hc_dev).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hc_devExists(id))
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

        // POST: api/Development
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<hc_dev>> Posthc_dev(hc_dev hc_dev)
        {
            _context.hc_development.Add(hc_dev);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethc_dev", new { id = hc_dev.Id }, hc_dev);
        }

        // DELETE: api/Development/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehc_dev(int id)
        {
            var hc_dev = await _context.hc_development.FindAsync(id);
            if (hc_dev == null)
            {
                return NotFound();
            }

            _context.hc_development.Remove(hc_dev);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool hc_devExists(int id)
        {
            return _context.hc_development.Any(e => e.Id == id);
        }
    }
}
