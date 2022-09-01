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
    public class DGOfficeController : ControllerBase
    {
        private readonly HC_DbContext _context;

        public DGOfficeController(HC_DbContext context)
        {
            _context = context;
        }

        // GET: api/DGOffice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hc_dgoffice>>> Gethc_dgoffice()
        {
            return await _context.hc_dgoffice.ToListAsync();
        }

        // GET: api/DGOffice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<hc_dgoffice>> Gethc_dgoffice(int id)
        {
            var hc_dgoffice = await _context.hc_dgoffice.FindAsync(id);

            if (hc_dgoffice == null)
            {
                return NotFound();
            }

            return hc_dgoffice;
        }

        // PUT: api/DGOffice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthc_dgoffice(int id, hc_dgoffice hc_dgoffice)
        {
            if (id != hc_dgoffice.Id)
            {
                return BadRequest();
            }

            _context.Entry(hc_dgoffice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hc_dgofficeExists(id))
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

        // POST: api/DGOffice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<hc_dgoffice>> Posthc_dgoffice(hc_dgoffice hc_dgoffice)
        {
            _context.hc_dgoffice.Add(hc_dgoffice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethc_dgoffice", new { id = hc_dgoffice.Id }, hc_dgoffice);
        }

        // DELETE: api/DGOffice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehc_dgoffice(int id)
        {
            var hc_dgoffice = await _context.hc_dgoffice.FindAsync(id);
            if (hc_dgoffice == null)
            {
                return NotFound();
            }

            _context.hc_dgoffice.Remove(hc_dgoffice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool hc_dgofficeExists(int id)
        {
            return _context.hc_dgoffice.Any(e => e.Id == id);
        }
    }
}
