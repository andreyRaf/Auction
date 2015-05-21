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
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private void DropDownInit()
        {
            StatusRepository statusRep = new StatusRepository();
            List<t_status> statusList = statusRep.Get().ToList();
            ViewBag.status = new SelectList(statusList, "statusID", "status", null);
        }

        [HttpGet]
        public ActionResult GetAdmin()
        {
            LotRepository lotRep = new LotRepository();
            Expression<Func<lot, bool>> filter = x => x.statusID == (int)Status.view;
            List<lot> lots = lotRep.Get(filter).ToList();

            DropDownInit();

            return View(lots);
        }

        [HttpPost]
        public ActionResult GetAdmin(lot change_lot)
        {
            LotRepository lotRep = new LotRepository();
            Expression<Func<lot, bool>> filter = x => x.lotID == change_lot.lotID;
            List<lot> c_lot = lotRep.Get(filter).ToList();
            c_lot[0].statusID = change_lot.statusID;
            lotRep.Save(c_lot[0]);

            filter = x => x.statusID == (int)Status.view;
            List<lot> lots = lotRep.Get(filter).ToList();

            DropDownInit();

            return View(lots);
        }

    }
}
