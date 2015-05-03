using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client
{
    public class LotFilter
    {
        public int? cityID { get; set; }
        public int? categoryID { get; set; }
        public string search { get; set; }
    }
}