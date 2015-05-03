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
