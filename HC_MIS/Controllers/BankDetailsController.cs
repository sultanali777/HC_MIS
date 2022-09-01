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
    public class BankDetailsController : ControllerBase
    {
        private readonly HC_DbContext _context;

        public BankDetailsController(HC_DbContext context)
        {
            _context = context;
        }

        // GET: api/BankDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hc_hfbankdetails>>> Gethc_hfbankdetails()
        {
            return await _context.hc_hfbankdetails.ToListAsync();
        }

        // GET: api/BankDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<hc_hfbankdetails>> Gethc_hfbankdetails(int id)
        {
            var hc_hfbankdetails = await _context.hc_hfbankdetails.FindAsync(id);

            if (hc_hfbankdetails == null)
            {
                return NotFound();
            }

            return hc_hfbankdetails;
        }

        // PUT: api/BankDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthc_hfbankdetails(int id, hc_hfbankdetails hc_hfbankdetails)
        {
            if (id != hc_hfbankdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(hc_hfbankdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hc_hfbankdetailsExists(id))
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

        // POST: api/BankDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<hc_hfbankdetails>> Posthc_hfbankdetails(hc_hfbankdetails hc_hfbankdetails)
        {
            _context.hc_hfbankdetails.Add(hc_hfbankdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethc_hfbankdetails", new { id = hc_hfbankdetails.Id }, hc_hfbankdetails);
        }

        // DELETE: api/BankDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehc_hfbankdetails(int id)
        {
            var hc_hfbankdetails = await _context.hc_hfbankdetails.FindAsync(id);
            if (hc_hfbankdetails == null)
            {
                return NotFound();
            }

            _context.hc_hfbankdetails.Remove(hc_hfbankdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool hc_hfbankdetailsExists(int id)
        {
            return _context.hc_hfbankdetails.Any(e => e.Id == id);
        }
    }
}
