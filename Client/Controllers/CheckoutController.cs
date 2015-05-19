using Server;
using Server.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class CheckoutController : Controller
    {
        //
        // GET: /CheckOut/
        private void DropDownInit()
        {
            CategoryRepository catRep = new CategoryRepository();
            List<category> categList = catRep.Get().ToList();
            ViewBag.categories = new SelectList(categList, "categoryID", "name", null);

            CityRepository cityRep = new CityRepository();
            List<city> cityList = cityRep.Get().ToList();
            ViewBag.cities = new SelectList(cityList, "cityID", "name", null);
        }

        [HttpGet]
        public ViewResult Checkout()
        {
            DropDownInit();
            return View(new lot());
        }

        [HttpPost]
        public ViewResult Checkout(lot new_lot)
        {

            LotRepository lotRep = new LotRepository();
            lotRep.Save(new_lot);

            return View("Thanks");
        }
    }
}
