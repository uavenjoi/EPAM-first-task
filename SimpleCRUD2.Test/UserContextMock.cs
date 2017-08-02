using System.Data.Entity;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Test
{
    internal class UserContextMock : DbContext, IUserContext
    {
        public UserContextMock()
            : base("DefaultConnection")
        {
        }

        public IDbSet<User> Users { get; set; }
    }
}
