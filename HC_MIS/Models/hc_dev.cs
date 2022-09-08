using System;

namespace HC_MIS.Models
{
    public class hc_dev
    {

        public int Id { get; set; }
        public string user_Id { get; set; }
        public string open_balance { get; set; }
        public string allocated_amount { get; set; }
        public string release_amount { get; set; }
        public string file_path { get; set; }
        public string hf_code { get; set; }
        //public string hf_fullname { get; set; }
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
