using System;
using System.Collections.Generic;

namespace HC_MIS.Models
{
    public class DataTableParameters
    {

        public int draw { get; set; }

        public int start { get; set; }

        public int end { get; set; }

        public int length { get; set; }

        public Search search { get; set; }

        public List<Order> order { get; set; }

        public List<Columns> columns { get; set; }

    }

    public class Search
    {
        public string value { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public class Columns
    {
        public string data { get; set; }
        public string name { get; set; }
    }
}
