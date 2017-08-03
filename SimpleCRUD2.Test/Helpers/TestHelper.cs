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
    }
}
