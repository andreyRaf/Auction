using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class NewLotController : Controller
    {
        //
        // GET: /NewLot/
        //public static NewLotObj newLot = null;

        public ViewResult NewLotPage()
        {
            NewLotObj newLot = new NewLotObj();
            newLot.lot = new Lot();
            newLot.city_category = new LotFilterDataModel()
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
                },
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
                }
            };
            return View(newLot);
        }

        [HttpPost]
        public ViewResult NewLot(NewLotObj newLot)
        {
            
            return View(newLot);
        }

    }
}
