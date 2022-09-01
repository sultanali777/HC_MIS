using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC_MIS.Models
{
    public class hc_hfbankdetails
    {
        public int Id { get; set; }
        public string user_Id { get; set; }
        public string bank_name { get; set; }
        public string hf_code { get; set; }
        public string bank_branch { get; set; }
        public string branch_code { get; set; }
        public string account_title { get; set; }
        public string account_no { get; set; }
        public string bank_contact { get; set; }
        public string account_status { get; set; }
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
