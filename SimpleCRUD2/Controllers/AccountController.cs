using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRUD2.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return this.View("Register");
        }
    }
}