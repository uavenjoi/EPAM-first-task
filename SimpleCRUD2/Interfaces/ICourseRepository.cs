﻿using System.Collections.Generic;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Interfaces
{
    public interface ICourseRepository
    {
        bool CreateCourse(string name);

        CourseModel GetCourseByName(string name);

        void AddLesson(CourseModel courseModel, LessonModel lessonModel);

        IEnumerable<CourseModel> GetReadyCourses();

        LessonModel GetLessonById(int id);

        void AddUserToMissingLesson(int userId, int lessonId);

        IEnumerable<LessonModel> GetLessonListForPage(int pageNumber, int pageSize, string courseName);
    }
}
