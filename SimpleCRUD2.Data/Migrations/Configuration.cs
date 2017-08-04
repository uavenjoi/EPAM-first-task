namespace SimpleCRUD2.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleCRUD2.Data.Models.UserContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SimpleCRUD2.Data.Models.UserContext context)
        {
            foreach (var user in context.Users)
            {
                context.Users.Remove(user);
            }

            foreach (var role in context.Roles)
            {
                context.Roles.Remove(role);
            }

            var admin = new User()
            {
                Name = "admin",
                Surname = "admin",
                Email = "admin@admin.com",
                Password = "admin"
            };

            var adminRole = new Role()
            {
                Name = "admin",
            };

            var moderRole = new Role()
            {
                Name = "moder",
            };

            var userRole = new Role()
            {
                Name = "user",
            };

            context.Users.Add(admin);

            context.Roles.Add(adminRole);
            context.Roles.Add(moderRole);
            context.Roles.Add(userRole);

            admin.Roles.Add(adminRole);
            admin.Roles.Add(moderRole);
            admin.Roles.Add(userRole);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
