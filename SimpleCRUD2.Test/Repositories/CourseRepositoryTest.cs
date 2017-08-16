using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Models;
using SimpleCRUD2.Repositories;

namespace SimpleCRUD2.Test.Repositories
{
    [TestFixture]
    public class CourseRepositoryTest
    {
        private CourseRepository repository;

        [SetUp]
        public void Initialize()
        {
            var mock = new Mock<IContext>();

            var lesson = new Lesson { LessonId = 1, Name = "test", DateTime = new DateTime(2000, 12, 02) };
            var lesson2 = new Lesson { Name = "test", DateTime = new DateTime(2000, 12, 01) };

            var user = new User() { UserId = 1 };
            var user2 = new User() { UserId = 2 };

            lesson.MissingUsers.Add(user);

            var lessons = new List<Lesson>() { lesson, lesson2 };

            mock.Setup(_ => _.Courses).Returns(new DbSetMock<Course>()
            {
                new Course
                {
                    CourseId = 1,
                    Name = "test",
                    IsDone = false,
                    Lessons = lessons
                },
                new Course { CourseId = 2, Name = "test2", IsDone = false },
                new Course { CourseId = 3, Name = "test3", IsDone = false },
                new Course { CourseId = 4, Name = "test4", IsDone = false },
                new Course { CourseId = 5, Name = "test5", IsDone = false },
            });

            mock.Setup(_ => _.Lessons).Returns(new DbSetMock<Lesson>()
            {
                lesson,
                lesson2
            });

            mock.Setup(_ => _.Users).Returns(new DbSetMock<User>()
            {
                user,
                user2
            });

            this.repository = new CourseRepository(mock.Object);
        }

        [Test]
        public void CreateCourse_ReturnsFalseIfNameCoincides()
        {
            bool result = (bool)this.repository.CreateCourse("test");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void CreateCourse_ReturnsTrueIfNameIsFree()
        {
            bool result = (bool)this.repository.CreateCourse("test1234");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void GetReadyCourses_ReturnsIEnumerableOfCourseModel()
        {
            IEnumerable<CourseModel> result = this.repository.GetReadyCourses() as IEnumerable<CourseModel>;

            Assert.IsInstanceOf(typeof(IEnumerable<CourseModel>), result);
        }

        [Test]
        public void GetAllLessons_ReturnsIEnumerableOfLessonModel()
        {
            IEnumerable<LessonModel> result = this.repository.GetAllLessons() as IEnumerable<LessonModel>;

            Assert.IsInstanceOf(typeof(IEnumerable<LessonModel>), result);
        }

        [Test]
        public void GetLessonListForPage_ReturnsIEnumerableOfLessonModel()
        {
            IEnumerable<LessonModel> result = this.repository.GetLessonListForPage(1, 2, "test") as IEnumerable<LessonModel>;

            Assert.IsInstanceOf(typeof(IEnumerable<LessonModel>), result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetCourseByName_ReturnsCourseModel()
        {
            CourseModel result = this.repository.GetCourseByName("test") as CourseModel;

            Assert.IsInstanceOf(typeof(CourseModel), result);
            Assert.AreEqual("test", result.Name);
        }

        [Test]
        public void GetLessonById_ReturnsLessonModel()
        {
            LessonModel result = this.repository.GetLessonById(1) as LessonModel;

            Assert.IsInstanceOf(typeof(LessonModel), result);
            Assert.AreEqual(1, result.LessonId);
        }

        [Test]
        public void AddLesson_WorksCorrectly()
        {
            var course = this.repository.GetCourseByName("test");
            var lessonMock = new LessonModel();
            var testCount = course.Lessons.Count;

            this.repository.AddLesson(course, lessonMock);
            var course2 = this.repository.GetCourseByName("test");
            var testCount2 = course2.Lessons.Count;

            Assert.AreEqual(testCount + 1, testCount2);
        }

        [Test]
        public void RemoveLessonById_WorksCorrectly()
        {
            this.repository.RemoveLessonById(1);
            var testDelegate = new TestDelegate(delegate() { this.repository.GetLessonById(1); });

            Assert.Throws<InvalidOperationException>(testDelegate);
            Assert.AreEqual(1, this.repository.GetAllLessons().Count());
        }

        [Test]
        public void AddUserToMissingLesson_WorksCorrectlyIfMissingUsersContainsUser()
        {
            this.repository.AddUserToMissingLesson(1, 1);
            var testCount = this.repository.GetLessonById(1).MissingUsers.Count;

            Assert.Zero(testCount);
        }

        [Test]
        public void AddUserToMissingLesson_WorksCorrectlyIfMissingUsersDoesNotContainsUser()
        {
            this.repository.AddUserToMissingLesson(2, 1);
            var testCount = this.repository.GetLessonById(1).MissingUsers.Count;

            Assert.AreEqual(2, testCount);
        }
    }
}
