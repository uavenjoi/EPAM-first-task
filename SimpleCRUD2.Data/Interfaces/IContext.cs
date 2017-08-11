using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Data.Interfaces
{
    public interface IContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Lesson> Lessons { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Role> Roles { get; set; }

        int SaveChanges();

        DbEntityEntry Entry(object entity);
    }
}
