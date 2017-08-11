using System;
using System.Data.Entity;
using SimpleCRUD2.Data.Interfaces;

namespace SimpleCRUD2.Data.Models
{
    public class UserContext : DbContext, IContext
    {
        public UserContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Role> Roles { get; set; }

        public IDbSet<Lesson> Lessons { get; set; }

        public IDbSet<Course> Courses { get; set; }

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

            modelBuilder.Entity<Lesson>()
                .HasMany<User>(_ => _.MissingUsers)
                .WithMany(_ => _.NotVisitedLessons)
                .Map(_ =>
                {
                    _.MapLeftKey("LessonRefId");
                    _.MapRightKey("UserId");
                    _.ToTable("UsersLessons");
                });

            modelBuilder.Entity<Course>()
                .HasMany<Lesson>(_ => _.Lessons)
                .WithOptional(_ => _.Course)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Lesson>()
                .Property(_ => _.DateTime)
                .HasColumnType("datetime2");

            base.OnModelCreating(modelBuilder);
        }
    }
}