using System;
using System.Collections.Generic;
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
            return TestHelper.GetFiveLessonsList();
        }

        public CourseModel GetCourseByName(string name)
        {
            return new CourseModel() { Name = name };
        }

        public LessonModel GetLessonById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LessonModel> GetLessonListForPage(int pageNumber, int pageSize, string courseName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseModel> GetReadyCourses()
        {
            throw new NotImplementedException();
        }

        public void RemoveLessonById(int lessonId)
        {
            throw new NotImplementedException();
        }
    }
}
