using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Client
{
    public class LotFilterDataModel
    {
        [DisplayName("Категория")]
        public List<Category> categories { get; set; }

        [DisplayName("Город")]
        public List<City> cities { get; set; }
    }
}
