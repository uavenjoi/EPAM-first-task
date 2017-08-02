using System;
using System.Linq;
using System.Web.Mvc;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels;

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
        public ActionResult Index(int page = 1)
        {
            var users = this.repository.GetUsersList();

            var pageSize = 5;

            var usersPerPage = users.Skip((page - 1) * pageSize).Take(pageSize);

            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = users.Count() };

            var viewModel = new IndexViewModel { PageInfo = pageInfo, Users = usersPerPage };

            return this.View("Index", viewModel);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return this.View("AddUser");
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

            return this.View("AddUser", userModel);
        }

        [HttpGet]
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "UserNotExistError")]
        public ActionResult EditUserInfo(int id)
        {
            var userModel = this.repository.GetUserById(id);
            return this.View("EditUserInfo", userModel);
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

            return this.View("EditUserInfo", userModel);
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            var userModel = this.repository.GetUserById(id);

            return this.View("DeleteUser", userModel);
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