namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdditionalPropertiestoPatientDataViewModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PatientDataViewModels", "PainScores_DataGroupField");
            DropColumn("dbo.PatientDataViewModels", "PainScores_DataTextField");
            DropColumn("dbo.PatientDataViewModels", "PainScores_DataValueField");
            DropColumn("dbo.PatientDataViewModels", "PainLocations_DataGroupField");
            DropColumn("dbo.PatientDataViewModels", "PainLocations_DataTextField");
            DropColumn("dbo.PatientDataViewModels", "PainLocations_DataValueField");
            DropColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataGroupField");
            DropColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataTextField");
            DropColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataValueField");
            DropColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataGroupField");
            DropColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataTextField");
            DropColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataValueField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataTextField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "ActivityLevelsToday_DataGroupField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataValueField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataTextField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "HoursOfSleepNightly_DataGroupField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainLocations_DataValueField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainLocations_DataTextField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainLocations_DataGroupField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainScores_DataValueField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainScores_DataTextField", c => c.String());
            AddColumn("dbo.PatientDataViewModels", "PainScores_DataGroupField", c => c.String());
        }
    }
}
