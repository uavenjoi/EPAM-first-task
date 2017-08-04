using System.Data.Entity;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Data.Interfaces
{
    public interface IUserContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Role> Roles { get; set; }

        int SaveChanges();
    }
}
