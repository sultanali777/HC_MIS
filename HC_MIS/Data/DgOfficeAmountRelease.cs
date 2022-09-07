using System;
using System.Collections.Generic;

#nullable disable

namespace HC_MIS.Data
{
    public partial class DgOfficeAmountRelease
    {
        public string Hfmiscode { get; set; }
        public string FullName { get; set; }
        public double? DevelopmentReleased { get; set; }
        public double? DgRelease { get; set; }
        public string AccountStatus { get; set; }
    }
}
