using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels;
using SimpleCRUD2.Models.ViewModels.HomeViewModels;

namespace SimpleCRUD2.Controllers
{
    [Authorize]
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class HomeController : Controller
    {
        private IUserRepository repository;

        public HomeController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index(int pageNumber = 1)
        {
            var pageSize = 5;
            
            var users = this.repository.GetUsersListForPage(pageNumber, pageSize);

            var pageInfo = new PageInfo { PageNumber = pageNumber, PageSize = pageSize, TotalItems = this.repository.UsersCount };

            var viewModel = new IndexViewModel { PageInfo = pageInfo, Users = users };

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
            if (ModelState.IsValid && this.repository.AddUser(userModel))
            {
                return this.RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Email's been registred");

            return this.View("AddUser", userModel);
        }

        [HttpGet]
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "UserNotExistError")]
        public ActionResult EditUserInfo(int id)
        {
            var userModel = this.repository.GetUserById(id);
            var editUserViewModel = new EditUserViewModel(userModel);

            return this.View("EditUserInfo", editUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserInfo(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                this.repository.EditUserInfo(editUserViewModel);

                return this.RedirectToAction("Index");
            }

            return this.View("EditUserInfo", editUserViewModel);
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