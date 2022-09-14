using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC_MIS.Models
{
    public class hc_meetingdetails
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Agenda { get; set; }
        public string hf_code { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string Aprovals { get; set; }
        //public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public bool RecordStatus { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdationDate { get; set; }
      // public DateTime MeetingDate { get; set; }
        public DateTime MeetingDate
        {
            get
            {
                return this.meetingdate.HasValue
                   ? this.meetingdate.Value
                   : DateTime.Now;
            }

            set { this.meetingdate = value; }
        }
        private DateTime? meetingdate = null;
    }
}






    





