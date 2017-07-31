using System.Data.Entity;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Data.Interfaces
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }
    }
}
