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

        public IDbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("dbo.Users");

            modelBuilder.Entity<Role>()
                .HasMany<User>(_ => _.Users)
                .WithMany(_ => _.Roles)
                .Map(_ =>
                {
                    _.MapLeftKey("RoleRefId");
                    _.MapRightKey("UserId");
                    _.ToTable("UsersRoles");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}