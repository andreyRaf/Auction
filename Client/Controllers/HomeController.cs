using Server;
using Server.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
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
        public ViewResult Index()
        {
            try
            {
                LotRepository lotRep = new LotRepository();
                Expression<Func<lot, bool>> filter = x => x.statusID == (int)Status.approve;
                List<lot> lots = lotRep.Get(filter).ToList();

                DropDownInit();

                LotsListViewModel model = new LotsListViewModel
                     {
                         lots = lots
                     };

                return View(model);
            }
            catch (Exception error)
            {
                return View();
            }
        }

        [HttpPost]
        public ViewResult Index(int? current_category, int? current_city, string part_name)
        {
            LotRepository lotRep = new LotRepository();
            Expression<Func<lot, bool>> filter =
                x => (x.cityID == current_city && current_city != null || current_city == null)
                              && (x.categoryID == current_category && current_category != null || current_category == null)
                              && (x.name.IndexOf(part_name.Trim()) != -1 && part_name.Trim() != "" || part_name.Trim() == "")
                              && x.statusID == (int)Status.approve;
            List<lot> lots = lotRep.Get(filter).ToList();

            DropDownInit();

            LotsListViewModel model = new LotsListViewModel
            {
                lots = lots
            };

            return View(model);
        }



        //[HttpPost]
        //public RedirectToRouteResult UpPrice(int lotID, LotFilter filter, int page)
        //{
        //    if (page <= 0)
        //    {
        //        throw new ArgumentException("page");
        //    }

        //    Lot lot = lots.First(e => e.lotID == lotID);
        //    lot.currentPrice += lot.step;

        //    return RedirectToAction("Index", new
        //    {
        //        page = page,
        //        categoryID = filter.categoryID,
        //        cityID = filter.cityID,
        //        search = filter.search
        //    });
        //}
    }
}
