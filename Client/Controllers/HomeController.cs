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
        public int PageSize = 3;
        static HomeController()
        {
            InitData();
        }

        private static void InitData()
        {
            lots = new List<Lot>();
            lots.Add(new Lot()
            {
                lotID = 1,
                name = "Mobila",
                image = "Content/Resources/image1.jpg",
                step = 100,
                blic = 1000,
                date = new DateTime(2014, 10, 1),
                categoryID = 1,
                cityID = 1
            });
            lots.Add(new Lot()
            {
                lotID = 2,
                name = "Ball",
                image = "Content/Resources/image2.jpg",
                step = 200,
                blic = 2000,
                date = new DateTime(2014, 11, 21),
                categoryID = 2,
                cityID = 1
            });
            lots.Add(new Lot()
            {
                lotID = 3,
                name = "Mobila 2",
                step = 300,
                blic = 3000,
                date = new DateTime(2013, 4, 14),
                categoryID = 1,
                cityID = 2
            });
            lots.Add(new Lot()
            {
                lotID = 4,
                name = "Ball 3",
                step = 140,
                blic = 1390,
                date = new DateTime(2015, 10, 1),
                categoryID = 2,
                cityID = 2
            });
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

        public ViewResult Index(LotFilter filter, int page = 1)
        {
            LotsListViewModel model = new LotsListViewModel
            {
                Lots = lots
                  .Where(e => filter == null || filter.categoryID == null || e.categoryID == filter.categoryID)
                  .Where(e => filter == null || filter.cityID == null || e.cityID == filter.cityID)
                  .OrderBy(p => p.lotID)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = lots
                      .Where(e => filter == null || filter.categoryID == null || e.categoryID == filter.categoryID)
                      .Where(e => filter == null || filter.cityID == null || e.cityID == filter.cityID)
                      .Count()
                },
                lotFilter = filter,
                filterData = new LotFilterDataModel()
                {
                    categories = categories,
                    cities = cities
                }
            };

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
