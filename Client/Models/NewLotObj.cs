using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client
{
    public class NewLotObj 
    {
        public Lot lot { get; set; }
        public LotFilterDataModel city_category { get; set; }
    }
}