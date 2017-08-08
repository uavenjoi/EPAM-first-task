using System.Web.Mvc;
using System.Web.Security;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models.ViewModels.AccountViewModels;

namespace SimpleCRUD2.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository repository;// рекомендуется переменные класса называть с нижнего подчеркивания _repository

        public AccountController(IUserRepository repository)
        {
            this.repository = repository; //чтобы потом можно было писать  _repository = repository. Нужно по возможности избегать this...., 
        }

        [HttpGet]
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            //Лучше будет если ValidateUser() будет принимать не 2 параметра а один типа LoginViewModel. 
            //А  внутри метода уже будет разбор на логин, пароль и тд
            if (ModelState.IsValid && this.repository.ValidateUser(loginViewModel.Email, loginViewModel.Password))
            {
                FormsAuthentication.SetAuthCookie(loginViewModel.Email, false);
                return this.RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "The email or password provided is incorrect.");

            return this.View("Login", loginViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.View("Login");
        }
    }
}
