using System.Data.Entity;
using SimpleCRUD2.Data.Interfaces;

namespace SimpleCRUD2.Data.Models
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("dbo.Users");

            base.OnModelCreating(modelBuilder);
        }
    }
}