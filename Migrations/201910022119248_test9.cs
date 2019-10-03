namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients");
            AddColumn("dbo.DailyPainJournals", "PatientId", c => c.Int());
            AddColumn("dbo.DailyPainJournals", "Patient_PatientId1", c => c.Int());
            CreateIndex("dbo.DailyPainJournals", "Patient_PatientId1");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId1", "dbo.Patients", "PatientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId1", "dbo.Patients");
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.DailyPainJournals", new[] { "Patient_PatientId1" });
            DropColumn("dbo.DailyPainJournals", "Patient_PatientId1");
            DropColumn("dbo.DailyPainJournals", "PatientId");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
    }
}
