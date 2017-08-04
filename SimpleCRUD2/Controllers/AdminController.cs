using System.Web.Mvc;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models.ViewModels.AdminViewModels;

namespace SimpleCRUD2.Controllers
{
    public class AdminController : Controller
    {
        private IUserRepository repository;

        public AdminController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            return this.View("Admin");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Admin(string email)
        {
            var userModel = this.repository.GetUserByEmail(email);
            var userRoles = this.repository.GetRolesForUser(email);

            if (userModel != null)
            {
                var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

                return this.View("UserRoles", userInfoViewModel);
            }

            return this.View("Admin");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult GiveUserAdminRole(int id)
        {
            var userModel = this.repository.GetUserById(id);

            var userIsAdmin = this.repository.IsUserInRole(userModel.Email, "admin");

            if (userIsAdmin)
            {
                string[] email = new string[] { userModel.Email };
                string[] role = new string[] { "admin" };

                this.repository.RemoveUsersFromRoles(email, role);

                var userRoles = this.repository.GetRolesForUser(userModel.Email);

                var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

                return this.View("UserRoles", userInfoViewModel);
            }
            else
            {
                string[] email = new string[] { userModel.Email };
                string[] role = new string[] { "admin" };

                this.repository.AddUsersToRoles(email, role);

                var userRoles = this.repository.GetRolesForUser(userModel.Email);

                var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

                return this.View("UserRoles", userInfoViewModel);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult GiveUserModerRole(int id)
        {
            var userModel = this.repository.GetUserById(id);

            var userIsModer = this.repository.IsUserInRole(userModel.Email, "moder");

            if (userIsModer)
            {
                string[] email = new string[] { userModel.Email };
                string[] role = new string[] { "moder" };

                this.repository.RemoveUsersFromRoles(email, role);

                var userRoles = this.repository.GetRolesForUser(userModel.Email);

                var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

                return this.View("UserRoles", userInfoViewModel);
            }
            else
            {
                string[] email = new string[] { userModel.Email };
                string[] role = new string[] { "moder" };

                this.repository.AddUsersToRoles(email, role);

                var userRoles = this.repository.GetRolesForUser(userModel.Email);

                var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

                return this.View("UserRoles", userInfoViewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult TakeAwayAllRoles(int id)
        {
            this.repository.RemoveUserFromAllRoles(id);

            var userModel = this.repository.GetUserById(id);
            var userRoles = this.repository.GetRolesForUser(userModel.Email);

            var userInfoViewModel = new UserInfoViewModel() { UserModel = userModel, UserRoles = userRoles };

            return this.View("UserRoles", userInfoViewModel);
        }
    }
}