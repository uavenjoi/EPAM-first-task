using SimpleCRUD2.Models;

namespace SimpleCRUD2.Interfaces
{
    public interface ICourseRepository
    {
        bool CreateCourse(string name);

        CourseModel GetCourseByName(string name);

        void AddLesson(CourseModel courseModel, LessonModel lessonModel);
    }
}
