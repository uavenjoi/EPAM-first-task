using System;
using System.Web.Mvc;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models.ViewModels.AdminViewModels;

namespace SimpleCRUD2.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IUserRepository repository;

        public AdminController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return this.View("Admin");
        }

        [HttpPost]
        public ActionResult Admin(string email)
        {
            var userModel = this.repository.GetUserByEmail(email);

            if (userModel == null)
            {
                this.TempData["UserIsNotFound"] = "User is not found";
                return this.View("Admin");
            }

            var userRoles = this.repository.GetRolesForUser(email);

            var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

            return this.View("UserRoles", userInfoViewModel);
        }

        [HttpGet]
        public ActionResult TakeAwayAllRoles(int id)
        {
            this.repository.RemoveUserFromAllRoles(id);

            var userModel = this.repository.GetUserById(id);

            var userRoles = this.repository.GetRolesForUser(userModel.Email);

            var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

            return this.View("UserRoles", userInfoViewModel);
        }

        [HttpPost]
        public ActionResult AddOrRemoveRole(int userId, string roleName)
        {
            var userModel = this.repository.GetUserById(userId);

            if (userModel == null)
            {
                return this.View("UserNotExistError");
            }

            var isUserInRole = this.repository.IsUserInRole(userModel.Email, roleName);

            if (isUserInRole)
            {
                string[] email = new string[] { userModel.Email };
                string[] role = new string[] { roleName };

                this.repository.RemoveUsersFromRoles(email, role);

                var userRoles = this.repository.GetRolesForUser(userModel.Email);

                var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

                return this.View("UserRoles", userInfoViewModel);
            }
            else
            {
                string[] email = new string[] { userModel.Email };
                string[] role = new string[] { roleName };

                this.repository.AddUsersToRoles(email, role);

                var userRoles = this.repository.GetRolesForUser(userModel.Email);

                var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

                return this.View("UserRoles", userInfoViewModel);
            }
        }
    }
}