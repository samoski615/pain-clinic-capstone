namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyPainJournals", "LogDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Providers", "SearchDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.DailyPainJournals", "SearchDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DailyPainJournals", "SearchDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Providers", "SearchDate");
            DropColumn("dbo.DailyPainJournals", "LogDate");
        }
    }
}
