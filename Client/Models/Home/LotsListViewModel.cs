using Server.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client
{
    public class LotsListViewModel
    {
        public IEnumerable<lot> lots { get; set; }
        public int? current_category { get; set; }
        public int? current_city { get; set; }
        public string part_name { get; set; }
    }
}