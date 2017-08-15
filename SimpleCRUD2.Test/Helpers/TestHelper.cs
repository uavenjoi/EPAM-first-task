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

        internal static IEnumerable<LessonModel> GetFiveLessonsList()
        {
            var lesson = new LessonModel() { LessonId = 1, Name = "l", DateTime = new DateTime(2001, 01, 01) };
            var lesson2 = new LessonModel() { LessonId = 2, Name = "ll", DateTime = new DateTime(2001, 01, 02) };
            var lesson3 = new LessonModel() { LessonId = 3, Name = "lll", DateTime = new DateTime(2001, 01, 03) };
            var lesson4 = new LessonModel() { LessonId = 4, Name = "llll", DateTime = new DateTime(2001, 01, 04) };
            var lesson5 = new LessonModel() { LessonId = 5, Name = "lllll", DateTime = new DateTime(2001, 01, 05) };

            var lessonsFake = new List<LessonModel>();
            lessonsFake.Add(lesson);
            lessonsFake.Add(lesson2);
            lessonsFake.Add(lesson3);
            lessonsFake.Add(lesson4);
            lessonsFake.Add(lesson5);

            return lessonsFake;
        }
    }
}
