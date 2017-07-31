using System;
using System.Web.Mvc;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Controllers
{
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class HomeController : Controller
    {
        private IUserRepository repository;

        public HomeController(IUserRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(this.repository.GetUsersList());
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddUser(userModel);

                return this.RedirectToAction("Index");
            }

            return this.View(userModel);
        }

        [HttpGet]
        public ActionResult EditUserInfo(int id)
        {
            var user = this.repository.GetUserById(id);
            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserInfo(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                this.repository.EditUserInfo(userModel);

                return this.RedirectToAction("Index");
            }

            return this.View(userModel);
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            return this.View(this.repository.GetUserById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserById(int id)
        {
            this.repository.DeleteUserById(id);

            return this.RedirectToAction("Index");
        }
    }
}