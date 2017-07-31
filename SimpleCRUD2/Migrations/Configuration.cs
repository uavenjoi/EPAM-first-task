namespace SimpleCRUD2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleCRUD2.Data.Models.UserContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "SimpleCRUD2.Data.Models.UserContext";
        }

        protected override void Seed(UserContext context)
        {
            using (var db = new UserContext())
            {
                User user1 = new User { Name = "Tom", Surname = "Holland", Location = "LA", Birthday = new DateTime(1990, 01, 19) };
                User user2 = new User { Name = "Sam", Surname = "Vinchester", Location = "HZ", Birthday = new DateTime(1988, 06, 12) };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
            }

            base.Seed(context);
        }
    }
}
