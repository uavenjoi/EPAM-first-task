using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private IContext context;

        public CourseRepository(IContext context)
        {
            this.context = context;
        }

        public bool CreateCourse(string name)
        {
            var searchCourse = this.context.Courses.FirstOrDefault(_ => _.Name == name);

            if (searchCourse == null)
            {
                var course = new Course() { Name = name };

                this.context.Courses.Add(course);
                this.context.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<CourseModel> GetReadyCourses()
        {
            var courses = this.context.Courses.Where(_ => _.IsDone).Select(_ => new CourseModel()
            {
                CourseId = _.CourseId,
                Name = _.Name,
                IsDone = _.IsDone,
                Lessons = _.Lessons.Select(l => new LessonModel()
                {
                    LessonId = l.LessonId,
                    Name = l.Name,
                    DateTime = l.DateTime,
                    MissingUsers = l.MissingUsers.Select(u => new UserModel()
                    {
                        UserId = u.UserId,
                        Name = u.Name,
                        Surname = u.Surname,
                        Birthday = u.Birthday,
                        Email = u.Email,
                        Location = u.Location
                    }).ToList()
                }).ToList()
            }).ToList();

            return courses;
        }

        public IEnumerable<LessonModel> GetLessonListForPage(int pageNumber, int pageSize, string courseName)
        {
            var course = this.context.Courses.Single(_ => _.Name == courseName);

            IEnumerable<LessonModel> lessons = course.Lessons.Select(_ => new LessonModel()
            {
                LessonId = _.LessonId,
                Name = _.Name,
                DateTime = _.DateTime,
                MissingUsers = _.MissingUsers.Select(u => new UserModel()
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Birthday = u.Birthday,
                    Email = u.Email,
                    Surname = u.Surname,
                    Location = u.Location
                }).ToList()
            }).ToList().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return lessons;
        }

        public CourseModel GetCourseByName(string name)
        {
            var courseModel = this.context.Courses.Where(_ => _.Name == name).Select(_ => new CourseModel()
            {
                CourseId = _.CourseId,
                Name = _.Name,
                IsDone = _.IsDone,
                Lessons = _.Lessons.Select(l => new LessonModel()
                {
                    LessonId = l.LessonId,
                    Name = l.Name,
                    DateTime = l.DateTime,
                    MissingUsers = l.MissingUsers.Select(u => new UserModel()
                    {
                        UserId = u.UserId,
                        Name = u.Name,
                        Surname = u.Surname,
                        Birthday = u.Birthday,
                        Email = u.Email,
                        Location = u.Location
                    }).ToList()
                }).ToList()
            }).Single();

            return courseModel;
        }

        public LessonModel GetLessonById(int id)
        {
            var lessonModel = this.context.Lessons.Where(_ => _.LessonId == id).Select(_ => new LessonModel()
            {
                LessonId = _.LessonId,
                Name = _.Name,
                DateTime = _.DateTime,
                MissingUsers = _.MissingUsers.Select(u => new UserModel()
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Surname = u.Surname,
                    Birthday = u.Birthday,
                    Email = u.Email,
                    Location = u.Location
                }).ToList()
            }).Single();

            return lessonModel;
        }

        public void AddLesson(CourseModel courseModel, LessonModel lessonModel)
        {
            var course = this.context.Courses.Single(_ => _.Name == courseModel.Name);

            var lesson = new Lesson() { Name = lessonModel.Name, DateTime = lessonModel.DateTime };

            course.IsDone = courseModel.IsDone;
            course.Lessons.Add(lesson);

            this.context.Lessons.Add(lesson);
            this.context.SaveChanges();
        }

        public void AddUserToMissingLesson(int userId, int lessonId)
        {
            var user = this.context.Users.Single(_ => _.UserId == userId);

            var lesson = this.context.Lessons.Single(_ => _.LessonId == lessonId);

            if (lesson.MissingUsers.Contains(user))
            {
                lesson.MissingUsers.Remove(user);
            }
            else
            {
                lesson.MissingUsers.Add(user);
            }

            this.context.SaveChanges();
        }
    }
}