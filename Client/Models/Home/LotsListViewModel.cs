using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client
{
    public class LotsListViewModel
    {
        public IEnumerable<Lot> Lots { get; set; }

        public PagingInfo PagingInfo { get; set; }
        public LotFilter lotFilter { get; set; }
        public LotFilterDataModel filterData { get; set; }
    }
}