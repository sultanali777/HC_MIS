using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HC_MIS.Data;
using HC_MIS.Models;
using Microsoft.AspNetCore.Authorization;

namespace HC_MIS.Controllers
{
    [AllowAnonymous]
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


        [HttpPost]
        [Route("DevelopmentBudget")]
        public async Task<ActionResult<IEnumerable<hc_dgoffice>>> GetDevelopmentBudget()
        {

            var resultsGroupings = _context.hc_dgoffice.GroupBy(r => new { r.release_amount, r.hf_code, r.date_entry })
                .Select(r => new
                {
                    Code = r.Key.hf_code,
                    Amount = r.Key.release_amount,
                    DateTime = r.Key.date_entry,
                });
            return Ok(resultsGroupings);

            //var Yoo = data.Select(x => new { x.Id, x.LetterNo, x.Name, x.Cnic, x.DesignationAppliedFor, x.IssueDate, DivisionName = x.HealthFacility != null ? x.HealthFacility.DivisionName : "", DistrictName = x.HealthFacility != null ? x.HealthFacility.DistrictName : "", TehsilName = x.HealthFacility != null ? x.HealthFacility.TehsilName : "", x.FinalReport }).ToList();
        }

        [HttpPost]
        [Route("DGOfficeReleasedBudget")]
        public async Task<ActionResult<IEnumerable<DgOfficeAmountRelease>>> GetDGOfficeRelease()
        {

            return await _context.DgOfficeAmountReleases.ToListAsync();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("DGDetailsSave")]
        public async Task<ActionResult<hc_dgoffice>> DGDATASAVE(hc_dgoffice hc_Dgoffice)
        {


            _context.Add(hc_Dgoffice);
            await _context.SaveChangesAsync();



            hc_hfAcknowledge obj = new hc_hfAcknowledge();
            obj.hf_code = hc_Dgoffice.hf_code;
            obj.cheque_no = hc_Dgoffice.cheque_no;
            obj.received_amount = hc_Dgoffice.release_amount;
            obj.DGOffice_Id = hc_Dgoffice.Id;
            obj.statusId = 1; // NOt Recieevd



            _context.Add(obj);
            await _context.SaveChangesAsync();


            return Ok();

            //return Ok();

            //var Yoo = data.Select(x => new { x.Id, x.LetterNo, x.Name, x.Cnic, x.DesignationAppliedFor, x.IssueDate, DivisionName = x.HealthFacility != null ? x.HealthFacility.DivisionName : "", DistrictName = x.HealthFacility != null ? x.HealthFacility.DistrictName : "", TehsilName = x.HealthFacility != null ? x.HealthFacility.TehsilName : "", x.FinalReport }).ToList();
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
