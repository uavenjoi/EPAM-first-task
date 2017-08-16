using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using SimpleCRUD2.Controllers;

namespace SimpleCRUD2.Test.Controllers
{
    [TestFixture]
    public class AdminControllerTest
    {
        private AdminController controller;

        [SetUp]
        public void Initialize()
        {
            this.controller = new AdminController(new UserRepositoryMock());
        }

        [Test]
        public void Admin_ReturnCorrectViewIfUserEqualsNull()
        {
            ViewResult result = this.controller.Admin(string.Empty) as ViewResult;

            Assert.AreEqual("Admin", result.ViewName);
        }

        [Test]
        public void Admin_ReturnCorrectViewIfUserExists()
        {
            ViewResult result = this.controller.Admin("true") as ViewResult;

            Assert.AreEqual("UserRoles", result.ViewName);
        }

        [Test]
        public void TakeAwayAllRoles_ReturnsCorrectView()
        {
            ViewResult result = this.controller.TakeAwayAllRoles(1) as ViewResult;

            Assert.AreEqual("UserRoles", result.ViewName);
        }

        [Test]
        public void AddOrRemoveRole_ReturnsCorrectViewIfUserEqualsNull()
        {
            ViewResult result = this.controller.AddOrRemoveRole(2, string.Empty) as ViewResult;

            Assert.AreEqual("UserNotExistError", result.ViewName);
        }

        [Test]
        public void AddOrRemoveRole_ReturnsCorrectViewIfUserIsInRole()
        {
            ViewResult result = this.controller.AddOrRemoveRole(1, "admin") as ViewResult;

            Assert.AreEqual("UserRoles", result.ViewName);
        }

        [Test]
        public void AddOrRemoveRole_ReturnsCorrectViewIfUserIsNotInRole()
        {
            ViewResult result = this.controller.AddOrRemoveRole(1, string.Empty) as ViewResult;

            Assert.AreEqual("UserRoles", result.ViewName);
        }
    }
}
