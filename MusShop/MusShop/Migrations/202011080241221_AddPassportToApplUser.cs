namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPassportToApplUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PassportId", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PassportId");
        }
    }
}
