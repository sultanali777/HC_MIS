using System;
using System.Collections.Generic;

#nullable disable

namespace HC_MIS.Data
{
    public partial class District
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OldCode { get; set; }
        public string CapitalTehsilCode { get; set; }
        public int? ProvinceId { get; set; }
        public int? DivisionId { get; set; }
    }
}
