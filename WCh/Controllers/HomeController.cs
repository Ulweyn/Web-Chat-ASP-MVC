﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCh.Controllers
{
    public class HomeController : Controller
    {
        Models.Chat chat = new Models.Chat();
        public ActionResult Index()
        {
            if (Session["Start"] != null && Convert.ToDateTime(Session["Start"]).AddSeconds(1000) <= DateTime.Now)
            {
                Session.Clear();
                Response.Redirect("/");
            }

            if (Request.Params["logout"] != null)
            {
                Session["userId"] = null;
                Response.Redirect("/");
            }






            if (Session["userId"] != null)
            {
                ViewBag.User = GetUserById(Convert.ToInt32(Session["userId"]));
            }
            else
            {
                string login = Request.Params["user_login"];//POST данные регистрации                
                string pass = Request.Params["user_pass"];
                if (login != null && pass != null)//Проверка на наличие данных
                {
                    Models.User user = GetUserByLogPass(login, pass);
                    if (user != null)
                    {
                        ViewBag.User = user;//пользователь по логину/паролю
                        Session["userId"] = user.Id;
                        Session["Start"] = DateTime.Now;

                    }
                }
            }

            ViewBag.Users = chat.Users;
            //ViewBag.Messages = chat.Messages;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public Models.User GetUserByLogPass(String login, String pass)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
                return null;

            var querry = from u in chat.Users where u.Nik.Equals(login) && u.Password.Equals(pass) select u;
            foreach (Models.User u in querry)
            {
                return u;
            }
            return null; // new User() { Nik = "123" };
        }
        public Models.User GetUserById(int id)
        {

            return chat.Users.Find(id);

        }
    }
}