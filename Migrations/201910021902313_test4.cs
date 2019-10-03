namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PatientDataViewModels", "PainScore");
            DropColumn("dbo.PatientDataViewModels", "PainLocation");
            DropColumn("dbo.PatientDataViewModels", "HoursOfSleep");
            DropColumn("dbo.PatientDataViewModels", "ActivityLevelToday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientDataViewModels", "ActivityLevelToday", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "HoursOfSleep", c => c.Int(nullable: false));
            AddColumn("dbo.PatientDataViewModels", "PainLocation", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainScore", c => c.Int(nullable: false));
        }
    }
}
