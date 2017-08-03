using System.Collections.Generic;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Interfaces
{
    public interface IUserRepository
    {
        int UsersCount { get; }

        IEnumerable<UserModel> GetUsersList();

        IEnumerable<UserModel> GetUsersListForPage(int pageNumber, int pageSize);

        void AddUser(UserModel user);

        void EditUserInfo(UserModel user);

        UserModel GetUserById(int id);

        void DeleteUserById(int id);
    }
}
