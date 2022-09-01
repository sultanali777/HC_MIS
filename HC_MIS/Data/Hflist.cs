using System;
using System.Collections.Generic;

#nullable disable

namespace HC_MIS.Data
{
    public partial class Hflist
    {
        public int Id { get; set; }
        public string Hfmiscode { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string TehsilCode { get; set; }
        public string TehsilName { get; set; }
    }
}
