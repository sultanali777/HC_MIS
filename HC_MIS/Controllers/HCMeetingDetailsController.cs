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
    public class HCMeetingDetailsController : ControllerBase
    {
        private readonly HC_DbContext _context;

        public HCMeetingDetailsController(HC_DbContext context)
        {
            _context = context;
        }

        // GET: api/HCMeetingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hc_meetingdetails>>> Gethc_meetingdetails()
        {
            return await _context.hc_meetingdetails.ToListAsync();
        }

        // GET: api/HCMeetingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<hc_meetingdetails>> Gethc_meetingdetails(int id)
        {
            var hc_meetingdetails = await _context.hc_meetingdetails.FindAsync(id);

            if (hc_meetingdetails == null)
            {
                return NotFound();
            }

            return hc_meetingdetails;
        }

        // PUT: api/HCMeetingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthc_meetingdetails(int id, hc_meetingdetails hc_meetingdetails)
        {
            if (id != hc_meetingdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(hc_meetingdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hc_meetingdetailsExists(id))
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

        // POST: api/HCMeetingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<hc_meetingdetails>> Posthc_meetingdetails(hc_meetingdetails hc_meetingdetails)
        {
            _context.hc_meetingdetails.Add(hc_meetingdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethc_meetingdetails", new { id = hc_meetingdetails.Id }, hc_meetingdetails);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("MeetingDetailsSave")]
        public async Task<ActionResult<hc_meetingdetails>> MeetingSAVE(hc_meetingdetails hc_Meetingdetails)
        {

            try
            {
                _context.Add(hc_Meetingdetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
           



            //hc obj = new hc_hfAcknowledge();
            //obj.hf_code = hc_Dgoffice.hf_code;
            //obj.cheque_no = hc_Dgoffice.cheque_no;
            //obj.received_amount = hc_Dgoffice.release_amount;
            //obj.DGOffice_Id = hc_Dgoffice.Id;
            //obj.statusId = 1; // NOt Recieevd



            //_context.Add(obj);
            //await _context.SaveChangesAsync();


            return Ok();

            //return Ok();

            //var Yoo = data.Select(x => new { x.Id, x.LetterNo, x.Name, x.Cnic, x.DesignationAppliedFor, x.IssueDate, DivisionName = x.HealthFacility != null ? x.HealthFacility.DivisionName : "", DistrictName = x.HealthFacility != null ? x.HealthFacility.DistrictName : "", TehsilName = x.HealthFacility != null ? x.HealthFacility.TehsilName : "", x.FinalReport }).ToList();
        }















        // DELETE: api/HCMeetingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehc_meetingdetails(int id)
        {
            var hc_meetingdetails = await _context.hc_meetingdetails.FindAsync(id);
            if (hc_meetingdetails == null)
            {
                return NotFound();
            }

            _context.hc_meetingdetails.Remove(hc_meetingdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool hc_meetingdetailsExists(int id)
        {
            return _context.hc_meetingdetails.Any(e => e.Id == id);
        }
    }
}
