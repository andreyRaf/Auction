using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Server.EF;
using Server.Repositories.ImplRepositories;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }        

        [HttpPost]
        public ViewResult Index(string Name, string Email, string Password)
        {
            try
            {
                UserRepository userRep = new UserRepository();
                Expression<Func<t_user, bool>> filter =
                x => (x.mail == Email && Email != null);
                List<t_user> users = userRep.Get(filter).ToList();
                LoginModel model = new LoginModel();

                if (users.Count > 0)
                {
                    return View(model);
                }
                else
                {
                    t_user newUser = new t_user();
                    newUser.name = Name;
                    newUser.mail = Email;
                    newUser.password = Password;
                    newUser.roleID = 2;
                    userRep.Save(newUser);

                    model.Name = Name;
                    model.Email = Email;
                    model.Password = Password;
                }

                return View(model);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
