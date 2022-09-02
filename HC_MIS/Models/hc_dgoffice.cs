using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC_MIS.Models
{
    public class hc_dgoffice
    {
        public int Id { get; set; }
        public string user_Id { get; set; }
        public string release_amount { get; set; }
        public string hf_code { get; set; }
        public string cheque_no { get; set; }
        public string courier_name { get; set; }
        public DateTime courier_date { get; set; }
        public string diary_no { get; set; }
        public string IsCancelled { get; set; }
        public string Remarks { get; set; }


        public DateTime date_entry
        {
            get
            {
                return this.dateEntry.HasValue
                   ? this.dateEntry.Value
                   : DateTime.Now;
            }

            set { this.dateEntry = value; }
        }
        private DateTime? dateEntry = null;
    }
}
