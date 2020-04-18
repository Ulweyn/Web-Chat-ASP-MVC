using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCh.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        Models.Chat chat = new Models.Chat();
        public ActionResult Index()
        {
            ViewBag.Users = chat.Users;
            return View();
        }


        [HttpPost]
        public string Add(Models.User user)
        {
           
            chat.Users.Add(user);
            chat.SaveChanges();

            return "<p>добавлено</b><hr/><a href='/Registration'>Взад</a>";
        }
    }
}