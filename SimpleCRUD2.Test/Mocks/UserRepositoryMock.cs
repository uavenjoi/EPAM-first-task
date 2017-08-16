using System;
using System.Collections.Generic;
using System.Linq;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels.HomeViewModels;

namespace SimpleCRUD2.Test
{
    internal class UserRepositoryMock : IUserRepository
    {
        public int UsersCount
        {
            get
            {
                return 7;
            }
        }

        public bool AddUser(UserModel user)
        {
            return true;
        }

        public void AddUsersToRoles(string[] emails, string[] roleNames)
        {
        }

        public void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(int id)
        {
        }

        public void EditUserInfo(EditUserViewModel editUserViewModel)
        {
        }

        public ICollection<Role> GetRolesForUser(string email)
        {
            return new List<Role>();
        }

        public IEnumerable<UserModel> GetStudentsUsersList()
        {
            return TestHelper.GetSevenUsersList();
        }

        public UserModel GetUserByEmail(string email)
        {
            var userModelFake = new UserModel();

            if (email == "true")
            {
                return userModelFake;
            }

            return null;
        }

        public UserModel GetUserById(int id)
        {
            var userModelFake = new UserModel()
            {
                Email = "test",
            };

            if (id == 1)
            {
                return userModelFake;
            }

            return null;
        }

        public IEnumerable<UserModel> GetUsersList()
        {
            return TestHelper.GetSevenUsersList();
        }

        public IEnumerable<UserModel> GetUsersListForPage(int pageNumber, int pageSize)
        {
            var fiveUsers = TestHelper.GetSevenUsersList().Skip(2);
            return fiveUsers;
        }

        public bool IsRegistred(string email)
        {
            return false;
        }

        public bool IsUserInRole(string email, string roleName)
        {
            if (email == "test" && roleName == "admin")
            {
                return true;
            }

            return false;
        }

        public void RemoveUserFromAllRoles(int id)
        {
        }

        public void RemoveUsersFromRoles(string[] emails, string[] roleNames)
        {
        }

        public bool ValidateUser(string email, string password)
        {
            return true;
        }
    }
}
