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
            var admin = new User() { UserId = 1, Name = "admin", Surname = "admin", Email = "admin@admin.com", Password = "admin" };
            context.Users.Add(admin);

            base.Seed(context);
        }
    }
}
