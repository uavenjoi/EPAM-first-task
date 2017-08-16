using System;
using System.Collections.Generic;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Test
{
    internal class TestHelper
    {
        internal static IEnumerable<UserModel> GetSevenUsersList()
        {
            var user = new UserModel() { UserId = 1, Name = "aaa", Surname = "bb" };
            var user2 = new UserModel() { UserId = 2, Name = "aaaa", Surname = "bbb" };
            var user3 = new UserModel() { UserId = 3, Name = "aaaaa", Surname = "bbbb" };
            var user4 = new UserModel() { UserId = 4, Name = "aaaaaa", Surname = "bbbbb" };
            var user5 = new UserModel() { UserId = 5, Name = "aaaaaaa", Surname = "bbbbbb" };
            var user6 = new UserModel() { UserId = 5, Name = "aaaaaaaa", Surname = "bbbbbbb" };
            var user7 = new UserModel() { UserId = 5, Name = "aaaaaaaaa", Surname = "bbbbbbbb" };

            var usersFake = new List<UserModel>();
            usersFake.Add(user);
            usersFake.Add(user2);
            usersFake.Add(user3);
            usersFake.Add(user4);
            usersFake.Add(user5);
            usersFake.Add(user6);
            usersFake.Add(user7);

            return usersFake;
        }

        internal static IEnumerable<LessonModel> GetTwelveLessonsList()
        {
            var lesson = new LessonModel() { LessonId = 1, Name = "l", DateTime = new DateTime(2001, 01, 01) };
            var lesson2 = new LessonModel() { LessonId = 2, Name = "ll", DateTime = new DateTime(2001, 01, 02) };
            var lesson3 = new LessonModel() { LessonId = 3, Name = "lll", DateTime = new DateTime(2001, 01, 03) };
            var lesson4 = new LessonModel() { LessonId = 4, Name = "llll", DateTime = new DateTime(2001, 01, 04) };
            var lesson5 = new LessonModel() { LessonId = 5, Name = "lllll", DateTime = new DateTime(2001, 01, 05) };
            var lesson6 = new LessonModel() { LessonId = 6, Name = "llllll", DateTime = new DateTime(2001, 01, 06) };
            var lesson7 = new LessonModel() { LessonId = 7, Name = "lllllll", DateTime = new DateTime(2001, 01, 07) };
            var lesson8 = new LessonModel() { LessonId = 8, Name = "llllllll", DateTime = new DateTime(2001, 01, 08) };
            var lesson9 = new LessonModel() { LessonId = 9, Name = "lllllllll", DateTime = new DateTime(2001, 01, 09) };
            var lesson10 = new LessonModel() { LessonId = 10, Name = "llllllllll", DateTime = new DateTime(2001, 01, 10) };
            var lesson11 = new LessonModel() { LessonId = 11, Name = "lllllllllll", DateTime = new DateTime(2001, 01, 11) };
            var lesson12 = new LessonModel() { LessonId = 12, Name = "llllllllllll", DateTime = new DateTime(2001, 01, 12) };

            var lessonsFake = new List<LessonModel>();
            lessonsFake.Add(lesson);
            lessonsFake.Add(lesson2);
            lessonsFake.Add(lesson3);
            lessonsFake.Add(lesson4);
            lessonsFake.Add(lesson5);
            lessonsFake.Add(lesson6);
            lessonsFake.Add(lesson7);
            lessonsFake.Add(lesson8);
            lessonsFake.Add(lesson9);
            lessonsFake.Add(lesson10);
            lessonsFake.Add(lesson11);
            lessonsFake.Add(lesson12);

            return lessonsFake;
        }

        internal static IEnumerable<CourseModel> GetThreeCoursesList()
        {
            var course = new CourseModel() { CourseId = 1, Name = "c" };
            var course2 = new CourseModel() { CourseId = 2, Name = "cc" };
            var course3 = new CourseModel() { CourseId = 3, Name = "ccc" }; 

            var coursesFake = new List<CourseModel>();
            coursesFake.Add(course);
            coursesFake.Add(course2);
            coursesFake.Add(course3);

            return coursesFake;
        }
    }
}
