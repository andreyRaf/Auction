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
            cities = City.GetCity();
            categories = Category.GetCategory();
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
