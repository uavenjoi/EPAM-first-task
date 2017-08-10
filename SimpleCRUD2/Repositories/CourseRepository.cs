using System.Linq;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private ICourseContext context;

        public CourseRepository(ICourseContext context)
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

        public CourseModel GetCourseByName(string name)
        {
            var course = this.context.Courses.Single(_ => _.Name == name);

            var courseModel = new CourseModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                IsDone = course.IsDone,
                Lessons = course.Lessons
            };

            return courseModel;
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
    }
}