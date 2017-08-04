using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels.HomeViewModels;

namespace SimpleCRUD2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IUserContext context;

        public UserRepository(IUserContext context)
        {
            this.context = context;
        }

        public int UsersCount
        {
            get
            {
                return this.context.Users.Count();
            }
        }

        public IEnumerable<UserModel> GetUsersList()
        {
            var users = this.context.Users.Select(_ => new UserModel()
            {
                UserId = _.UserId,
                Name = _.Name,
                Surname = _.Surname,
                Email = _.Email,
                Location = _.Location,
                Birthday = _.Birthday
            }).ToList();

            return users;
        }

        public IEnumerable<UserModel> GetUsersListForPage(int pageNumber, int pageSize)
        {
            IEnumerable<UserModel> users = this.context.Users.Select(_ => new UserModel()
            {
                UserId = _.UserId,
                Name = _.Name,
                Surname = _.Surname,
                Email = _.Email,
                Location = _.Location,
                Birthday = _.Birthday
            }).ToList().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return users;
        }

        public void EditUserInfo(EditUserViewModel editUserViewModel)
        {
            var user = this.context.Users.Where(_ => _.UserId == editUserViewModel.UserId).FirstOrDefault();
            
            user.Name = editUserViewModel.Name;
            user.Surname = editUserViewModel.Surname;
            user.Location = editUserViewModel.Location;
            user.Birthday = editUserViewModel.Birthday;

            this.context.SaveChanges();
        }

        public bool AddUser(UserModel userModel)
        {
            var user = this.context.Users.Where(_ => _.Email == userModel.Email).FirstOrDefault();

            if (user == null)
            {
                var newUser = new User()
                {
                    UserId = userModel.UserId,
                    Email = userModel.Email,
                    Password = "temp",
                    Name = userModel.Name,
                    Surname = userModel.Surname,
                    Location = userModel.Location,
                    Birthday = userModel.Birthday
                };

                this.context.Users.Add(newUser);
                this.context.SaveChanges();

                return true;
            }

            return false;
        }

        public UserModel GetUserById(int id)
        {
            var user = this.context.Users.Where(_ => _.UserId == id).FirstOrDefault();
            var userModel = new UserModel(user);
            
            return userModel;
        }

        public void DeleteUserById(int id)
        {
            var user = this.context.Users.Where(_ => _.UserId == id).FirstOrDefault();

            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }

        public bool ValidateUser(string email, string password)
        {
            var user = this.context.Users.Where(_ => _.Email == email && _.Password == password).FirstOrDefault();
            if (user != null)
            {
                return true;
            }

            return false;
        }

        public bool IsRegistred(string email)
        {
            var user = this.context.Users.Where(_ => _.Email == email).FirstOrDefault();
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}