using System.Web.Mvc;
using NUnit.Framework;
using SimpleCRUD2.Controllers;
using SimpleCRUD2.Models.ViewModels.AccountViewModels;

namespace SimpleCRUD2.Test.Controllers
{
    [TestFixture]
    public class AccountControllerTest
    {
        private AccountController controller;

        [SetUp]
        public void Initialize()
        {
            this.controller = new AccountController(new UserRepositoryMock());
        }

        [Test]
        public void Login_ReturnCorrectViewIfModelIsNotValid()
        {
            var mockModel = new LoginViewModel();

            this.controller.ModelState.AddModelError(string.Empty, string.Empty);

            ViewResult result = this.controller.Login(mockModel) as ViewResult;

            Assert.AreEqual("Login", result.ViewName);
        }
    }
}
