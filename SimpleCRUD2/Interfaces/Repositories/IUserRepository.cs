using System.Collections.Generic;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels.HomeViewModels;

namespace SimpleCRUD2.Interfaces
{
    public interface IUserRepository
    {
        // Users methods
        #region
        int UsersCount { get; }

        IEnumerable<UserModel> GetUsersList();

        IEnumerable<UserModel> GetUsersListForPage(int pageNumber, int pageSize);

        IEnumerable<UserModel> GetStudentsUsersList();

        bool AddUser(UserModel user);

        void EditUserInfo(EditUserViewModel editUserViewModel);

        UserModel GetUserByEmail(string email);

        UserModel GetUserById(int id);

        void DeleteUserById(int id);

        bool ValidateUser(string email, string password);

        bool IsRegistred(string email);
        #endregion

        // Roles methods
        #region
        ICollection<Role> GetRolesForUser(string email);

        void CreateRole(string roleName);

        bool IsUserInRole(string email, string roleName);

        void RemoveUsersFromRoles(string[] emails, string[] roleNames);

        void AddUsersToRoles(string[] emails, string[] roleNames);

        void RemoveUserFromAllRoles(int id);
        #endregion
    }
}
