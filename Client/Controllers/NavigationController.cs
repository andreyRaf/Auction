using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class NavigationController : Controller
    {
        private static List<City> cities;
        private static List<Category> categories;
        private static void InitData()
        {
            cities = DbUtils.GetCity();
            categories = DbUtils.GetCategory();
        }

        public NavigationController()
        {
            InitData();
        }
        public PartialViewResult Index()
        {
            LotFilterDataModel obj = new LotFilterDataModel()
            {
                categories = categories,
                cities = cities
            };

            return PartialView(obj);
        }

    }
}
