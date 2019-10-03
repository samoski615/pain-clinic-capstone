namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyPainJournals", "SearchDateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.DailyPainJournals", "SearchDateEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.DailyPainJournals", "Date");
            DropColumn("dbo.PatientDataViewModels", "SearchDateStart");
            DropColumn("dbo.PatientDataViewModels", "SearchDateEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientDataViewModels", "SearchDateEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientDataViewModels", "SearchDateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.DailyPainJournals", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.DailyPainJournals", "SearchDateEnd");
            DropColumn("dbo.DailyPainJournals", "SearchDateStart");
        }
    }
}
