using System.Collections.Generic;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsersList();

        void AddUser(UserModel user);

        void EditUserInfo(UserModel user);

        UserModel GetUserById(int id);

        void DeleteUserById(int id);
    }
}
