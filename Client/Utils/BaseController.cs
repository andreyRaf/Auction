using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Utils
{
    public abstract class BaseController : Controller
    {
        private static List<City> cities;
        private static List<Category> categories;
        private static void InitData()
        {
            cities = DbUtils.GetCity();
            categories = DbUtils.GetCategory();
        }

        protected BaseController()
        {
            InitData();

            LotFilterDataModel obj = new LotFilterDataModel()
            {
                categories = categories,
                cities = cities
            };
            this.ViewBag._LayoutModel = obj;
        }

    }
}
