using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC_MIS.Models
{
    public class hc_meetingmember

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }

        public string RecordStatus { get; set; }
        public int? meetingFKid { get; set; }








    }
}
