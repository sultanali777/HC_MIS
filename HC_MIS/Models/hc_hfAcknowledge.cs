using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC_MIS.Models
{
    public class hc_hfAcknowledge
    {
        public int Id { get; set; }
        public string user_Id { get; set; }
        public string received_amount { get; set; }
        public string hf_code { get; set; }
        public string file_path { get; set; }
        public string cheque_no { get; set; }
        public int statusId { get; set; }
        public DateTime received_date { get; set; }
        public int? DGOffice_Id { get; set; }

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
