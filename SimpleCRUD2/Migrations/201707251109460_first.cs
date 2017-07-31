namespace SimpleCRUD2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            this.DropColumn("dbo.Users", "Description");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Users", "Description", c => c.String());
        }
    }
}
