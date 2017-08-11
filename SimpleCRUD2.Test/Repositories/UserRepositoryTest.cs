using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Models;
using SimpleCRUD2.Repositories;

namespace SimpleCRUD2.Test
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private UserRepository repository;

        [SetUp]
        public void Initialize()
        {
            var mock = new Mock<IContext>();

            var testRole = new Role { Name = "test" };
            var testRole2 = new Role { Name = "test2" };

            mock.Setup(_ => _.Users).Returns(new DbSetMock<User>()
            {
                new User
            {
                    UserId = 1,
                    Name = "aa",
                    Surname = "aa",
                    Email = "test",
                    Roles = new List<Role> { testRole }
            },
                new User { UserId = 2, Name = "aa", Surname = "aa" },
                new User { UserId = 3, Name = "aa", Surname = "aa" },
                new User { UserId = 4, Name = "aa", Surname = "aa" },
                new User { UserId = 5, Name = "aa", Surname = "aa" },
                new User { UserId = 6, Name = "aa", Surname = "aa" },
                new User { UserId = 7, Name = "aa", Surname = "aa" }
            });

            mock.Setup(_ => _.Roles).Returns(new DbSetMock<Role>()
            {
                testRole,
                testRole2
            });

            this.repository = new UserRepository(mock.Object);
        }

        [Test]
        public void GetUsersList_ReturnsIEnumerableOfUserModel()
        {
            IEnumerable<UserModel> result = this.repository.GetUsersList() as IEnumerable<UserModel>;

            Assert.IsInstanceOf(typeof(IEnumerable<UserModel>), result);
        }

        [Test]
        public void GetUsersListForPage_ReturnsIEnumerableOfUserModel()
        {
            IEnumerable<UserModel> result = this.repository.GetUsersListForPage(1, 5) as IEnumerable<UserModel>;

            Assert.IsInstanceOf(typeof(IEnumerable<UserModel>), result);
            Assert.AreEqual(5, result.Count());
        }

        [Test]
        public void GetUserById_ReturnsCorrectUserModel()
        {
            UserModel result = this.repository.GetUserById(1) as UserModel;

            Assert.IsInstanceOf(typeof(UserModel), result);
            Assert.AreEqual(1, result.UserId);
        }

        [Test]
        public void GetUserById_ReturnsNullIfUserNotExist()
        {
            UserModel result = this.repository.GetUserById(8) as UserModel;

            Assert.AreEqual(null, result);
        }

        [Test]
        public void GetUserByEmail_ReturnsCorrectUserModel()
        {
            UserModel result = this.repository.GetUserByEmail("test") as UserModel;

            Assert.IsInstanceOf(typeof(UserModel), result);
            Assert.AreEqual(1, result.UserId);
        }

        [Test]
        public void GetUserByEmail_ReturnsNullIfUserNotExist()
        {
            UserModel result = this.repository.GetUserByEmail(string.Empty) as UserModel;

            Assert.AreEqual(null, result);
        }

        [Test]
        public void DeleteUserById_WorksCorrectly()
        {
            var userCount = this.repository.GetUsersList().Count();

            this.repository.DeleteUserById(7);

            var newUserCount = this.repository.GetUsersList().Count();

            Assert.AreEqual(userCount, newUserCount + 1);
        }

        [Test]
        public void GetRolesForUser_ReturnCorrectValue()
        {
            ICollection<Role> result = this.repository.GetRolesForUser("test") as ICollection<Role>;

            Assert.IsInstanceOf(typeof(ICollection<Role>), result);
            Assert.AreEqual("test", result.First().Name);
        }

        [Test]
        public void GetRolesForUser_ReturnCorrectValueIfUserEqualsNull()
        {
            ICollection<Role> test = new List<Role>();
            ICollection<Role> result = this.repository.GetRolesForUser(string.Empty) as ICollection<Role>;

            Assert.AreEqual(test, result);
        }

        [Test]
        public void IsUserInRole_ReturnCorrectValue()
        {
            bool result = this.repository.IsUserInRole("test", "test");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsUserInRole_ReturnCorrectValueIfUserEqualsNull()
        {
            bool result = this.repository.IsUserInRole(string.Empty, "test");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsUserInRole_ReturnCorrectValueIfRoleEqualsNull()
        {
            bool result = this.repository.IsUserInRole("test", string.Empty);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsUserInRole_ReturnCorrectValueIfUserOutOfRole()
        {
            bool result = this.repository.IsUserInRole("test", "test2");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void RemoveUsersFromRoles_WorksCorrectly()
        {
            var user = this.repository.GetUserById(1);
            string[] email = new string[] { user.Email };
            string[] role = new string[] { "test" };
            var test = this.repository.IsUserInRole(user.Email, "test");

            this.repository.RemoveUsersFromRoles(email, role);
            var test2 = this.repository.IsUserInRole(user.Email, "test");

            Assert.AreNotEqual(test, test2);
        }

        [Test]
        public void AddUsersToRoles_WorksCorrectly()
        {
            var user = this.repository.GetUserById(1);
            string[] email = new string[] { user.Email };
            string[] role = new string[] { "test2" };
            var test = this.repository.IsUserInRole(user.Email, "test2");

            this.repository.AddUsersToRoles(email, role);
            var test2 = this.repository.IsUserInRole(user.Email, "test2");

            Assert.AreNotEqual(test, test2);
        }

        [Test]
        public void RemoveUserFromAllRoles_WorksCorrectly()
        {
            var test = this.repository.IsUserInRole("test", "test");

            this.repository.RemoveUserFromAllRoles(1);
            var test2 = this.repository.IsUserInRole("test", "test");

            Assert.AreNotEqual(test, test2);
        }
    }
}
