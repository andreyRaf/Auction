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
            cities = new List<City>() 
            {
                new City()
                {
                    cityID = 1,
                    name = "Казань"
                },
                new City()
                {
                    cityID = 2,
                    name = "Челны"
                }
            };
            categories = new List<Category>() 
            {
                new Category()
                {
                    categoryID = 1,
                    name = "Техника"
                },
                new Category()
                {
                    categoryID = 2,
                    name = "Спорт"
                }
            };
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
