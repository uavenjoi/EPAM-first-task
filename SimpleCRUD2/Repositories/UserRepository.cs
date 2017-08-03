using System.Collections.Generic;
using System.Linq;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

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
                Location = _.Location,
                Birthday = _.Birthday
            }).ToList().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return users;
        }

        public void EditUserInfo(UserModel userModel)
        {
            var user = this.context.Users.Where(_ => _.UserId == userModel.UserId).FirstOrDefault();

            user.Name = userModel.Name;
            user.Surname = userModel.Surname;
            user.Location = userModel.Location;
            user.Birthday = userModel.Birthday;

            this.context.SaveChanges();
        }

        public void AddUser(UserModel userModel)
        {
            var user = new User()
            {
                UserId = userModel.UserId,
                Name = userModel.Name,
                Surname = userModel.Surname,
                Location = userModel.Location,
                Birthday = userModel.Birthday
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
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
    }
}