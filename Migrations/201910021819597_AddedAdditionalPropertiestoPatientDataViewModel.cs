namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdditionalPropertiestoPatientDataViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyPainJournals", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientDataViewModels", "SearchDateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientDataViewModels", "SearchDateEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientDataViewModels", "PainScore", c => c.Int(nullable: false));
            AddColumn("dbo.PatientDataViewModels", "PainScores_DataGroupField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainScores_DataTextField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainScores_DataValueField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainLocation", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainLocations_DataGroupField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainLocations_DataTextField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainLocations_DataValueField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "HoursOfSleep", c => c.Int(nullable: false));
            AddColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataGroupField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataTextField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataValueField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "ActivityLevelToday", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataGroupField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataTextField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataValueField", c => c.String());
            DropColumn("dbo.DailyPainJournals", "TodaysDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DailyPainJournals", "TodaysDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataValueField");
            DropColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataTextField");
            DropColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataGroupField");
            DropColumn("dbo.PatientDataViewModels", "ActivityLevelToday");
            DropColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataValueField");
            DropColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataTextField");
            DropColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataGroupField");
            DropColumn("dbo.PatientDataViewModels", "HoursOfSleep");
            DropColumn("dbo.PatientDataViewModels", "PainLocations_DataValueField");
            DropColumn("dbo.PatientDataViewModels", "PainLocations_DataTextField");
            DropColumn("dbo.PatientDataViewModels", "PainLocations_DataGroupField");
            DropColumn("dbo.PatientDataViewModels", "PainLocation");
            DropColumn("dbo.PatientDataViewModels", "PainScores_DataValueField");
            DropColumn("dbo.PatientDataViewModels", "PainScores_DataTextField");
            DropColumn("dbo.PatientDataViewModels", "PainScores_DataGroupField");
            DropColumn("dbo.PatientDataViewModels", "PainScore");
            DropColumn("dbo.PatientDataViewModels", "SearchDateEnd");
            DropColumn("dbo.PatientDataViewModels", "SearchDateStart");
            DropColumn("dbo.DailyPainJournals", "Date");
        }
    }
}
