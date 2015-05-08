using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Lot
    {
        public int lotID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double? currentPrice { get; set; }
        public double? step { get; set; }
        public double? blic { get; set; }
        public DateTime? date { get; set; }
        public string image { get; set; }
        public int? cityID { get; set; }
        public int? categoryID { get; set; }
    }


}
