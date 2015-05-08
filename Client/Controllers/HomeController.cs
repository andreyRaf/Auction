using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private static List<Lot> lots = null;
        private static List<City> cities = null;
        private static List<Category> categories = null;
        public static int PageSize = 3;
        static HomeController()
        {
            InitData();
        }

        private static void InitData()
        {
            lots = DbUtils.GetLot(1, PageSize);
            cities = DbUtils.GetCity();
            categories = DbUtils.GetCategory();
        }

        public ViewResult Index(LotFilter filter, int page = 1)
        {
            List<Lot> lots = DbUtils.GetLot(filter.cityID, filter.categoryID, page, PageSize);
            LotsListViewModel model = null;
            if (lots != null)
            {
                model = new LotsListViewModel
                 {
                     Lots = lots.Take(PageSize),
                     PagingInfo = new PagingInfo
                     {
                         CurrentPage = page,
                         ItemsPerPage = PageSize,
                         TotalItems = DbUtils.GetCountLot(filter.cityID, filter.categoryID)
                     },
                     lotFilter = filter,
                     filterData = new LotFilterDataModel()
                     {
                         categories = categories,
                         cities = cities
                     }
                 };
            }

            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult UpPrice(int lotID, LotFilter filter, int page)
        {
            if (page <= 0)
            {
                throw new ArgumentException("page");
            }

            Lot lot = lots.First(e => e.lotID == lotID);
            lot.currentPrice += lot.step;

            return RedirectToAction("Index", new
            {
                page = page,
                categoryID = filter.categoryID,
                cityID = filter.cityID,
                search = filter.search
            });
        }
    }
}
