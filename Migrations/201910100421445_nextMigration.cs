namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Providers", "SearchDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "SearchDate", c => c.DateTime(nullable: false));
        }
    }
}
