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
    public class CommonController : ControllerBase
    {

        private HC_DbContext Context { get; }
        public CommonController(HC_DbContext _context)
        {
            this.Context = _context;
        }
        [HttpPost]
        [Route("Facilities")]
        public async Task<ActionResult<IEnumerable<Hflist>>> GetFacilities(string code)
        {
            return await Context.HFList.Where(x => x.DistrictCode == code).ToListAsync();
        }
        [HttpGet]
        [Route("Status")]
        public async Task<ActionResult<IEnumerable<hc_ackStatus>>> GetStatus()
        {
            return await Context.hc_ackStatus.ToListAsync();
        }
        [HttpGet]
        [Route("Districts")]
        public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
        {
            return await Context.Districts.ToListAsync();
        }
    }
}
