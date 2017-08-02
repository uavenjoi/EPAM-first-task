using System.Collections.Generic;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Test
{
    internal class UserRepositoryMock : IUserRepository
    {
        public void AddUser(UserModel user)
        {
        }

        public void DeleteUserById(int id)
        {
        }

        public void EditUserInfo(UserModel user)
        {
        }

        public UserModel GetUserById(int id)
        {
            var userModelFake = new UserModel();

            return userModelFake;
        }

        public IEnumerable<UserModel> GetUsersList()
        {
            return TestHelper.GetSevenUsersList();
        }
    }
}
