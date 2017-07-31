namespace SimpleCRUD2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Location = c.String(),
                        Description = c.String(),
                        Birthday = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
        }
        
        public override void Down()
        {
            this.DropTable("dbo.Users");
        }
    }
}
