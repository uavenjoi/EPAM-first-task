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
            var mock = new Mock<IUserContext>();
            mock.Setup(_ => _.Users).Returns(new DbSetMock<User>()
            {
                new User { UserId = 1, Name = "aa", Surname = "aa" },
                new User { UserId = 2, Name = "aa", Surname = "aa" },
                new User { UserId = 3, Name = "aa", Surname = "aa" },
                new User { UserId = 4, Name = "aa", Surname = "aa" },
                new User { UserId = 5, Name = "aa", Surname = "aa" },
                new User { UserId = 6, Name = "aa", Surname = "aa" },
                new User { UserId = 7, Name = "aa", Surname = "aa" }
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
    }
}
