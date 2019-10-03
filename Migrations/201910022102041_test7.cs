namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyPainJournals", "SearchDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailyPainJournals", "SearchDate");
        }
    }
}
