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
    public class AcknowledgeController : ControllerBase
    {
        private readonly HC_DbContext _context;

        public AcknowledgeController(HC_DbContext context)
        {
            _context = context;
        }

        // GET: api/Acknowledge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hc_hfAcknowledge>>> Gethc_hfAcknowledge()
        {
            return await _context.hc_hfAcknowledge.ToListAsync();
        }

        // GET: api/Acknowledge/5
        [HttpGet("{id}")]
        public async Task<ActionResult<hc_hfAcknowledge>> Gethc_hfAcknowledge(int id)
        {
            var hc_hfAcknowledge = await _context.hc_hfAcknowledge.FindAsync(id);

            if (hc_hfAcknowledge == null)
            {
                return NotFound();
            }

            return hc_hfAcknowledge;
        }

        // PUT: api/Acknowledge/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthc_hfAcknowledge(int id, hc_hfAcknowledge hc_hfAcknowledge)
        {
            if (id != hc_hfAcknowledge.Id)
            {
                return BadRequest();
            }

            _context.Entry(hc_hfAcknowledge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hc_hfAcknowledgeExists(id))
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

        // POST: api/Acknowledge
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<hc_hfAcknowledge>> Posthc_hfAcknowledge(hc_hfAcknowledge hc_hfAcknowledge)
        {
            _context.hc_hfAcknowledge.Add(hc_hfAcknowledge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethc_hfAcknowledge", new { id = hc_hfAcknowledge.Id }, hc_hfAcknowledge);
        }

        // DELETE: api/Acknowledge/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehc_hfAcknowledge(int id)
        {
            var hc_hfAcknowledge = await _context.hc_hfAcknowledge.FindAsync(id);
            if (hc_hfAcknowledge == null)
            {
                return NotFound();
            }

            _context.hc_hfAcknowledge.Remove(hc_hfAcknowledge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool hc_hfAcknowledgeExists(int id)
        {
            return _context.hc_hfAcknowledge.Any(e => e.Id == id);
        }
    }
}
