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
    public class CommonController : ControllerBase
    {

        private HC_DbContext Context { get; }
        public CommonController(HC_DbContext _context)
        {
            this.Context = _context;
        }
        [HttpPost]
        [Route("Facilities")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetFacilities()
        {
            return await Context.HFList.ToListAsync();
        }
        [HttpPost]
        [Route("FacilitiesByDivision")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetFacilitiesByDivision(string code)
        {
            return await Context.HFList.Where(x => x.DivisionCode == code).ToListAsync();
        }
        [HttpPost]
        [Route("FacilitiesByDistrict")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetFacilities(string code)
        {
            return await Context.HFList.Where(x => x.DistrictCode == code).ToListAsync();
        }
        [HttpGet]
        [Route("FacilitiesByTehsils")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetFacilitiesByTehsils(string code)
        {
            return await Context.HFList.Where(x => x.TehsilCode == code).ToListAsync();
        }
        [HttpPost]
        [Route("FacilitiesByType")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetFacilitiesByType(string code)
        {
            return await Context.HFList.Where(x => x.HFTypeCode == code).ToListAsync();
        }
        [HttpGet]
        [Route("Status")]
        public async Task<ActionResult<IEnumerable<hc_ackStatus>>> GetStatus()
        {
            return await Context.hc_ackStatus.ToListAsync();
        }
        [HttpGet]
        [Route("Divisions")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetDivisions()
        {

            var resultsGroupings = Context.HFList.GroupBy(r => new { r.DivisionCode, r.DivisionName })
                                    .Select(r => new
                                    {
                                        Code = r.Key.DivisionCode,
                                        Name = r.Key.DivisionName
                                    });


            return Ok(resultsGroupings);
        }
        [HttpGet]
        [Route("Districts")]
        public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
        {
            return await Context.Districts.ToListAsync();
        }
        [HttpGet]
        [Route("DistrictsByDivision")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetDivDistricts(string code)
        {
            var resultsGroupings = Context.HFList.GroupBy(r => new { r.DistrictCode, r.DistrictName, r.DivisionCode })
                .Where(a => a.Key.DivisionCode == code)
                .Select(r => new
                {
                    Code = r.Key.DistrictCode,
                    Name = r.Key.DistrictName
                });


            return Ok(resultsGroupings);
        }
        [HttpGet]
        [Route("TehsilsByDistrict")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetDisTehsils(string code)
        {
            var resultsGroupings = Context.HFList.GroupBy(r => new { r.TehsilCode, r.TehsilName, r.DistrictCode })
                .Where(a => a.Key.DistrictCode == code)
                .Select(r => new
                {
                    Code = r.Key.TehsilCode,
                    Name = r.Key.TehsilName
                });
            return Ok(resultsGroupings);
        }
        [HttpPost]
        [Route("FacilityTypes")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetFacilityTypes()
        {
            var resultsGroupings = Context.HFList.GroupBy(r => new { r.HFTypeCode, r.HFTypeName })
                .Select(r => new
                {
                    Code = r.Key.HFTypeCode,
                    Name = r.Key.HFTypeName
                });
            return Ok(resultsGroupings);
        }
        [HttpGet]
        [Route("Tehsils")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetTehsils()
        {
            var resultsGroupings = Context.HFList.GroupBy(r => new { r.TehsilCode, r.TehsilName, r.DistrictCode })
                .Select(r => new
                {
                    Code = r.Key.TehsilCode,
                    Name = r.Key.TehsilName
                });
            return Ok(resultsGroupings);
        }
    }
}
