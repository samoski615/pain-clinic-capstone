namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedPropertyforDailyActivitiesonDailyPainJournal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DailyPainJournals", "DailyActivities");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DailyPainJournals", "DailyActivities", c => c.String());
        }
    }
}
