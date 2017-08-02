using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using SimpleCRUD2.Controllers;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels;

namespace SimpleCRUD2.Test
{
    [TestFixture]
    internal class HomeControllerTest
    {
        private HomeController controller;

        [SetUp]
        public void Initialize()
        {
            this.controller = new HomeController(new UserRepositoryMock());
        }

        [Test]
        public void AddUser_ReturnCorrectView()
        {
            ViewResult result = this.controller.AddUser() as ViewResult;

            Assert.AreEqual("AddUser", result.ViewName);
        }

        [Test]
        public void AddUser_ReturnCorrectValueIfModelIsValid()
        {
            var userModel = new UserModel();

            RedirectToRouteResult result = this.controller.EditUserInfo(userModel) as RedirectToRouteResult;

            Assert.IsInstanceOf(typeof(RedirectToRouteResult), result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void AddUser_ReturnCorrectViewIfModelIsNotValid()
        {
            var userModel = new UserModel();

            this.controller.ModelState.AddModelError(string.Empty, string.Empty);

            ViewResult result = this.controller.AddUser(userModel) as ViewResult;

            Assert.AreEqual("AddUser", result.ViewName);
        }

        [Test]
        public void Index_ReturnCorrectView()
        {
            ViewResult result = this.controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Index_UserListTest()
        {
            ViewResult result = this.controller.Index(1) as ViewResult;

            Assert.IsInstanceOf(typeof(IEnumerable<UserModel>), ((IndexViewModel)result.Model).Users);
            Assert.AreEqual(5, ((IndexViewModel)result.Model).Users.Count());

            ViewResult result2 = this.controller.Index(2) as ViewResult;

            Assert.IsInstanceOf(typeof(IEnumerable<UserModel>), ((IndexViewModel)result2.Model).Users);
            Assert.AreEqual(2, ((IndexViewModel)result2.Model).Users.Count());
        }

        [Test]
        public void Index_PageInfoTest()
        {
            ViewResult result = this.controller.Index(1) as ViewResult;

            var model = result.Model as IndexViewModel;

            Assert.IsInstanceOf(typeof(PageInfo), model.PageInfo);
            Assert.AreEqual(2, model.PageInfo.PageCountPerPage);
            Assert.AreEqual(1, model.PageInfo.PageNumber);
            Assert.AreEqual(5, model.PageInfo.PageSize);
            Assert.AreEqual(7, model.PageInfo.TotalItems);
            Assert.AreEqual(2, model.PageInfo.TotalPages);
            Assert.AreEqual(2, model.PageInfo.PageCountPerPage);

            ViewResult result2 = this.controller.Index(2) as ViewResult;

            var model2 = result2.Model as IndexViewModel;

            Assert.IsInstanceOf(typeof(PageInfo), model2.PageInfo);
            Assert.AreEqual(2, model2.PageInfo.PageCountPerPage);
            Assert.AreEqual(2, model2.PageInfo.PageNumber);
            Assert.AreEqual(5, model2.PageInfo.PageSize);
            Assert.AreEqual(7, model2.PageInfo.TotalItems);
            Assert.AreEqual(2, model2.PageInfo.TotalPages);
            Assert.AreEqual(2, model2.PageInfo.PageCountPerPage);
        }

        [Test]
        public void EditUserInfo_ReturnCorrectView()
        {
            ViewResult result = this.controller.EditUserInfo(1) as ViewResult;

            Assert.AreEqual("EditUserInfo", result.ViewName);
        }

        [Test]
        public void EditUserInfo_ReturnCorrectValueIfModelIsValid()
        {
            var userModel = new UserModel();

            RedirectToRouteResult result = this.controller.EditUserInfo(userModel) as RedirectToRouteResult;

            Assert.IsInstanceOf(typeof(RedirectToRouteResult), result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void EditUserInfo_ReturnCorrectViewIfModelIsNotValid()
        {
            var userModel = new UserModel();

            this.controller.ModelState.AddModelError(string.Empty, string.Empty);

            ViewResult result = this.controller.EditUserInfo(userModel) as ViewResult;

            Assert.AreEqual("EditUserInfo", result.ViewName);
        }

        [Test]
        public void DeleteUser_ReturnCorrectView()
        {
            ViewResult result = this.controller.DeleteUser(1) as ViewResult;

            Assert.AreEqual("DeleteUser", result.ViewName);

            ViewResult result2 = this.controller.DeleteUser(1000000) as ViewResult;

            Assert.AreEqual("DeleteUser", result2.ViewName);

            ViewResult result3 = this.controller.DeleteUser(1000000000) as ViewResult;

            Assert.AreEqual("DeleteUser", result3.ViewName);
        }

        [Test]
        public void DeleteUserById_ReturnCorrectView()
        {
            ViewResult result = this.controller.DeleteUserById(1) as ViewResult;

            Assert.AreEqual("Index", result.ViewName);

            ViewResult result2 = this.controller.DeleteUserById(1000000) as ViewResult;

            Assert.AreEqual("Index", result2.ViewName);

            ViewResult result3 = this.controller.DeleteUserById(1000000000) as ViewResult;

            Assert.AreEqual("Index", result3.ViewName);
        }
    }
}
