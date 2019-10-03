namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddropdownlistforToCreateDailyLog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DailyPainJournals", "PainRating", c => c.String(nullable: false));
            AlterColumn("dbo.DailyPainJournals", "PainLocation", c => c.String(nullable: false));
            AlterColumn("dbo.DailyPainJournals", "AmountOfSleep", c => c.String(nullable: false));
            AlterColumn("dbo.DailyPainJournals", "ActivityLevel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DailyPainJournals", "ActivityLevel", c => c.String());
            AlterColumn("dbo.DailyPainJournals", "AmountOfSleep", c => c.String());
            AlterColumn("dbo.DailyPainJournals", "PainLocation", c => c.String());
            AlterColumn("dbo.DailyPainJournals", "PainRating", c => c.String());
        }
    }
}
