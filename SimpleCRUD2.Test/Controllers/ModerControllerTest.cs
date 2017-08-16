using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using SimpleCRUD2.Controllers;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels.ModerViewModels;
using SimpleCRUD2.Test.Mocks;

namespace SimpleCRUD2.Test.Controllers
{
    [TestFixture]
    public class ModerControllerTest
    {
        private ModerController controller;

        [SetUp]
        public void Initialize()
        {
            this.controller = new ModerController(new CourseRepositoryMock(), new UserRepositoryMock());
        }

        [Test]
        public void OpenJournal_ReturnCorrectView()
        {
            ViewResult result = this.controller.OpenJournal() as ViewResult;

            Assert.AreEqual("OpenJournal", result.ViewName);
        }

        [Test]
        public void CourseInfo_ReturnCorrectView()
        {
            ViewResult result = this.controller.CourseInfo(string.Empty) as ViewResult;

            Assert.AreEqual("CourseInfo", result.ViewName);
        }

        [Test]
        public void CourseInfo_LessonListTest()
        {
            ViewResult result = this.controller.CourseInfo(string.Empty, 2) as ViewResult;

            Assert.IsInstanceOf(typeof(IEnumerable<LessonModel>), ((CourseInfoViewModel)result.Model).Lessons);
            Assert.AreEqual(2, ((CourseInfoViewModel)result.Model).Lessons.Count());
        }

        [Test]
        public void CourseInfo_PageInfoTestOne()
        {
            ViewResult result = this.controller.CourseInfo(string.Empty) as ViewResult;

            var model = result.Model as CourseInfoViewModel;

            Assert.IsInstanceOf(typeof(PageInfo), model.PageInfo);
            Assert.AreEqual(2, model.PageInfo.PageCountPerPage);
            Assert.AreEqual(1, model.PageInfo.PageNumber);
            Assert.AreEqual(10, model.PageInfo.PageSize);
            Assert.AreEqual(12, model.PageInfo.TotalItems);
            Assert.AreEqual(2, model.PageInfo.TotalPages);
        }

        [Test]
        public void CourseInfo_PageInfoTestTwo()
        {
            ViewResult result2 = this.controller.CourseInfo(string.Empty, 2) as ViewResult;

            var model2 = result2.Model as CourseInfoViewModel;

            Assert.IsInstanceOf(typeof(PageInfo), model2.PageInfo);
            Assert.AreEqual(2, model2.PageInfo.PageCountPerPage);
            Assert.AreEqual(2, model2.PageInfo.PageNumber);
            Assert.AreEqual(10, model2.PageInfo.PageSize);
            Assert.AreEqual(12, model2.PageInfo.TotalItems);
            Assert.AreEqual(2, model2.PageInfo.TotalPages);
        }
    }
}
