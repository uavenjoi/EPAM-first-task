using System;
using System.Collections.Generic;
using System.Linq;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Test.Mocks
{
    public class CourseRepositoryMock : ICourseRepository
    {
        public void AddLesson(CourseModel courseModel, LessonModel lessonModel)
        {
        }

        public void AddUserToMissingLesson(int userId, int lessonId)
        {
        }

        public bool CreateCourse(string name)
        {
            if (name == "test")
            {
                return true;
            }

            return false;
        }

        public IEnumerable<LessonModel> GetAllLessons()
        {
            return TestHelper.GetTwelveLessonsList();
        }

        public CourseModel GetCourseByName(string name)
        {
            var course = new CourseModel() { Name = name };
            
            foreach (var lesson in TestHelper.GetTwelveLessonsList())
            {
                course.Lessons.Add(lesson);
            }

            return course;
        }

        public LessonModel GetLessonById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LessonModel> GetLessonListForPage(int pageNumber, int pageSize, string courseName)
        {
            return TestHelper.GetTwelveLessonsList().Skip(10);
        }

        public IEnumerable<CourseModel> GetReadyCourses()
        {
            return TestHelper.GetThreeCoursesList();
        }

        public void RemoveLessonById(int lessonId)
        {
            throw new NotImplementedException();
        }
    }
}
