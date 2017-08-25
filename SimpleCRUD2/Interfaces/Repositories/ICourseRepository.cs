using System.Collections.Generic;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Interfaces
{
    public interface ICourseRepository
    {
        void CreateCourseFromCourseModel(CourseModel courseModel);

        bool CreateCourse(string name);

        void DeleteCourseById(int id);

        CourseModel GetCourseByName(string name);

        void AddLesson(CourseModel courseModel, LessonModel lessonModel);

        void RemoveLessonById(int lessonId);

        IEnumerable<CourseModel> GetReadyCourses();

        IEnumerable<LessonModel> GetAllLessons();

        LessonModel GetLessonById(int id);

        void AddUserToMissingLesson(int userId, int lessonId);

        IEnumerable<LessonModel> GetLessonListForPage(int pageNumber, int pageSize, string courseName);
    }
}
