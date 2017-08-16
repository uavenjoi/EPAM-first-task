using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SimpleCRUD2.Controllers;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels;
using SimpleCRUD2.Models.ViewModels.HomeViewModels;

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

            RedirectToRouteResult result = this.controller.AddUser(userModel) as RedirectToRouteResult;

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
        }

        [Test]
        public void Index_PageInfoTestOne()
        {
            ViewResult result = this.controller.Index(1) as ViewResult;

            var model = result.Model as IndexViewModel;

            Assert.IsInstanceOf(typeof(PageInfo), model.PageInfo);
            Assert.AreEqual(2, model.PageInfo.PageCountPerPage);
            Assert.AreEqual(1, model.PageInfo.PageNumber);
            Assert.AreEqual(5, model.PageInfo.PageSize);
            Assert.AreEqual(7, model.PageInfo.TotalItems);
            Assert.AreEqual(2, model.PageInfo.TotalPages);
        }

        [Test]
        public void Index_PageInfoTestTwo()
        {
            ViewResult result2 = this.controller.Index(2) as ViewResult;

            var model2 = result2.Model as IndexViewModel;

            Assert.IsInstanceOf(typeof(PageInfo), model2.PageInfo);
            Assert.AreEqual(2, model2.PageInfo.PageCountPerPage);
            Assert.AreEqual(2, model2.PageInfo.PageNumber);
            Assert.AreEqual(5, model2.PageInfo.PageSize);
            Assert.AreEqual(7, model2.PageInfo.TotalItems);
            Assert.AreEqual(2, model2.PageInfo.TotalPages);
        }

        [Test]
        public void EditUserInfo_ReturnCorrectView()
        {
            var mock = new Mock<IPrincipal>();
            mock.Setup(_ => _.IsInRole("admin")).Returns(true);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(_ => _.User)
                       .Returns(mock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(_ => _.HttpContext)
                                 .Returns(contextMock.Object);

            this.controller.ControllerContext = controllerContextMock.Object;

            ViewResult result = this.controller.EditUserInfo(1) as ViewResult;

            Assert.AreEqual("EditUserInfo", result.ViewName);
        }

        [Test]
        public void EditUserInfo_ReturnCorrectViewIfUserHaveNoRights()
        {
            var mock = new Mock<IPrincipal>();
            mock.Setup(_ => _.IsInRole("admin")).Returns(false);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(_ => _.User)
                       .Returns(mock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(_ => _.HttpContext)
                                 .Returns(contextMock.Object);

            this.controller.ControllerContext = controllerContextMock.Object;

            ViewResult result = this.controller.EditUserInfo(1) as ViewResult;

            Assert.AreEqual("NotEnoughRightsError", result.ViewName);
        }

        [Test]
        public void EditUserInfo_ReturnCorrectViewIfUserEqualsNull()
        {
            ViewResult result = this.controller.EditUserInfo(2) as ViewResult;

            Assert.AreEqual("UserNotExistError", result.ViewName);
        }

        [Test]
        public void EditUserInfo_ReturnCorrectValueIfModelIsValid()
        {
            var editUserViewModel = new EditUserViewModel();

            RedirectToRouteResult result = this.controller.EditUserInfo(editUserViewModel) as RedirectToRouteResult;

            Assert.IsInstanceOf(typeof(RedirectToRouteResult), result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void EditUserInfo_ReturnCorrectViewIfModelIsNotValid()
        {
            var editUserViewModel = new EditUserViewModel();

            this.controller.ModelState.AddModelError(string.Empty, string.Empty);

            ViewResult result = this.controller.EditUserInfo(editUserViewModel) as ViewResult;

            Assert.AreEqual("EditUserInfo", result.ViewName);
        }

        [Test]
        public void DeleteUser_ReturnCorrectViewIfUserHaveRights()
        {
            var mock = new Mock<IPrincipal>();
            mock.Setup(_ => _.IsInRole("admin")).Returns(true);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(_ => _.User)
                       .Returns(mock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(_ => _.HttpContext)
                                 .Returns(contextMock.Object);

            this.controller.ControllerContext = controllerContextMock.Object;

            ViewResult result = this.controller.DeleteUser(1) as ViewResult;

            Assert.AreEqual("DeleteUser", result.ViewName);
        }

        [Test]
        public void DeleteUser_ReturnCorrectViewIfUserHaveNoRights()
        {
            var mock = new Mock<IPrincipal>();
            mock.Setup(_ => _.IsInRole("admin")).Returns(false);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(_ => _.User)
                       .Returns(mock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(_ => _.HttpContext)
                                 .Returns(contextMock.Object);

            this.controller.ControllerContext = controllerContextMock.Object;

            ViewResult result = this.controller.DeleteUser(1) as ViewResult;

            Assert.AreEqual("NotEnoughRightsError", result.ViewName);
        }

        [Test]
        public void DeleteUser_ReturnCorrectViewIfUserEqualsNull()
        {
            var mock = new Mock<IPrincipal>();
            mock.Setup(_ => _.IsInRole("admin")).Returns(false);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(_ => _.User)
                       .Returns(mock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(_ => _.HttpContext)
                                 .Returns(contextMock.Object);

            this.controller.ControllerContext = controllerContextMock.Object;

            ViewResult result = this.controller.DeleteUser(2) as ViewResult;

            Assert.AreEqual("UserNotExistError", result.ViewName);
        }

        [Test]
        public void DeleteUserById_ReturnCorrectViewIfUserHaveNoRights()
        {
            var mock = new Mock<IPrincipal>();
            mock.Setup(_ => _.IsInRole("admin")).Returns(false);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(_ => _.User)
                       .Returns(mock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(_ => _.HttpContext)
                                 .Returns(contextMock.Object);

            this.controller.ControllerContext = controllerContextMock.Object;

            ViewResult result = this.controller.DeleteUserById(1) as ViewResult;

            Assert.AreEqual("NotEnoughRightsError", result.ViewName);
        }

        [Test]
        public void DeleteUserById_ReturnCorrectViewIfUserEqualsNull()
        {
            var mock = new Mock<IPrincipal>();
            mock.Setup(_ => _.IsInRole("admin")).Returns(false);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(_ => _.User)
                       .Returns(mock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(_ => _.HttpContext)
                                 .Returns(contextMock.Object);

            this.controller.ControllerContext = controllerContextMock.Object;

            ViewResult result = this.controller.DeleteUserById(2) as ViewResult;

            Assert.AreEqual("UserNotExistError", result.ViewName);
        }

        [Test]
        public void DeleteUserById_ReturnCorrectView()
        {
            var mock = new Mock<IPrincipal>();
            mock.Setup(_ => _.IsInRole("admin")).Returns(true);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(_ => _.User)
                       .Returns(mock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(_ => _.HttpContext)
                                 .Returns(contextMock.Object);

            this.controller.ControllerContext = controllerContextMock.Object;

            RedirectToRouteResult result = this.controller.DeleteUserById(1) as RedirectToRouteResult;

            Assert.IsInstanceOf(typeof(RedirectToRouteResult), result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
