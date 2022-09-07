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


        [HttpPost]
        [Route("IssueCheque")]
        public async Task<ActionResult<IEnumerable<hc_hfAcknowledge>>> GetIssueCheque()
        {

            var resultsGroupings = _context.hc_dgoffice.GroupBy(r => new { r.release_amount, r.hf_code, r.date_entry,r.cheque_no,r.courier_date,r.courier_name,r.diary_no })
                .Select(r => new
                {
                    HFCode = r.Key.hf_code,
                    ChequeAmount = r.Key.release_amount,
                    DateTime = r.Key.date_entry,
                    ChequeNo= r.Key.cheque_no,
                    CourierName=r.Key.courier_name,
                    CourierDate=r.Key.courier_date,
                    DairyNo=r.Key.diary_no

                });
            return Ok(resultsGroupings);

            //var Yoo = data.Select(x => new { x.Id, x.LetterNo, x.Name, x.Cnic, x.DesignationAppliedFor, x.IssueDate, DivisionName = x.HealthFacility != null ? x.HealthFacility.DivisionName : "", DistrictName = x.HealthFacility != null ? x.HealthFacility.DistrictName : "", TehsilName = x.HealthFacility != null ? x.HealthFacility.TehsilName : "", x.FinalReport }).ToList();
        }





        [HttpPost]
        [Route("HFDetailsSave")]
        public async Task<ActionResult<IEnumerable<hc_hfAcknowledge>>> DATASAVE(hc_hfAcknowledge hc_HfAcknowledge)
        {

            _context.Add(hc_HfAcknowledge);
            await _context.SaveChangesAsync();
            return Ok();

            //var Yoo = data.Select(x => new { x.Id, x.LetterNo, x.Name, x.Cnic, x.DesignationAppliedFor, x.IssueDate, DivisionName = x.HealthFacility != null ? x.HealthFacility.DivisionName : "", DistrictName = x.HealthFacility != null ? x.HealthFacility.DistrictName : "", TehsilName = x.HealthFacility != null ? x.HealthFacility.TehsilName : "", x.FinalReport }).ToList();
        }

      























        [HttpPost]
        [Route("HFbudget")]
        public async Task<ActionResult<IEnumerable<hc_hfAcknowledge>>> GetHFBudget()
        {

            var result = (from hfc in _context.hc_dgoffice
                          join abc in _context.hc_hfAcknowledge on hfc.Id equals abc.DGOffice_Id
                          select new
                          {
                              HFCode = hfc.hf_code,
                              id = hfc.Id,
                              ChequeNo = hfc.cheque_no,
                              CourierName = hfc.courier_name,
                              CourierDate = hfc.courier_date,
                              DairyNo = hfc.diary_no,
                              ReceivedAmmount = abc.received_amount,
                              Remarks = hfc.Remarks,
                              Status = abc.statusId,
                              DateTime = hfc.date_entry
                          }).ToList();



        


            return Ok(result);



            //var Yoo = data.Select(x => new { x.Id, x.LetterNo, x.Name, x.Cnic, x.DesignationAppliedFor, x.IssueDate, DivisionName = x.HealthFacility != null ? x.HealthFacility.DivisionName : "", DistrictName = x.HealthFacility != null ? x.HealthFacility.DistrictName : "", TehsilName = x.HealthFacility != null ? x.HealthFacility.TehsilName : "", x.FinalReport }).ToList();
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
