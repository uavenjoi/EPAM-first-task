using System.Collections.Generic;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels.HomeViewModels;

namespace SimpleCRUD2.Interfaces
{
    public interface IUserRepository
    {
        int UsersCount { get; }

        IEnumerable<UserModel> GetUsersList();

        IEnumerable<UserModel> GetUsersListForPage(int pageNumber, int pageSize);

        bool AddUser(UserModel user);

        void EditUserInfo(EditUserViewModel editUserViewModel);

        UserModel GetUserById(int id);

        void DeleteUserById(int id);

        bool ValidateUser(string email, string password);

        bool IsRegistred(string email);
    }
}
