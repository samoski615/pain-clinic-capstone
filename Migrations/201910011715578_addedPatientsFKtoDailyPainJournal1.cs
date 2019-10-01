namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPatientsFKtoDailyPainJournal1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DailyPainJournalPatients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals");
            DropForeignKey("dbo.DailyPainJournalPatients", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.DailyPainJournalPatients", new[] { "DailyPainJournal_DailyPainJournalId" });
            DropIndex("dbo.DailyPainJournalPatients", new[] { "Patient_PatientId" });
            AddColumn("dbo.Patients", "DailyPainJournal_DailyPainJournalId", c => c.Int());
            AddColumn("dbo.DailyPainJournals", "PatientId", c => c.Int());
            AddColumn("dbo.DailyPainJournals", "Patient_PatientId", c => c.Int());
            AddColumn("dbo.DailyPainJournals", "Patient_PatientId1", c => c.Int());
            CreateIndex("dbo.Patients", "DailyPainJournal_DailyPainJournalId");
            CreateIndex("dbo.DailyPainJournals", "Patient_PatientId");
            CreateIndex("dbo.DailyPainJournals", "Patient_PatientId1");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Patients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals", "DailyPainJournalId");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId1", "dbo.Patients", "PatientId");
            DropTable("dbo.DailyPainJournalPatients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DailyPainJournalPatients",
                c => new
                    {
                        DailyPainJournal_DailyPainJournalId = c.Int(nullable: false),
                        Patient_PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DailyPainJournal_DailyPainJournalId, t.Patient_PatientId });
            
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId1", "dbo.Patients");
            DropForeignKey("dbo.Patients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals");
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.DailyPainJournals", new[] { "Patient_PatientId1" });
            DropIndex("dbo.DailyPainJournals", new[] { "Patient_PatientId" });
            DropIndex("dbo.Patients", new[] { "DailyPainJournal_DailyPainJournalId" });
            DropColumn("dbo.DailyPainJournals", "Patient_PatientId1");
            DropColumn("dbo.DailyPainJournals", "Patient_PatientId");
            DropColumn("dbo.DailyPainJournals", "PatientId");
            DropColumn("dbo.Patients", "DailyPainJournal_DailyPainJournalId");
            CreateIndex("dbo.DailyPainJournalPatients", "Patient_PatientId");
            CreateIndex("dbo.DailyPainJournalPatients", "DailyPainJournal_DailyPainJournalId");
            AddForeignKey("dbo.DailyPainJournalPatients", "Patient_PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.DailyPainJournalPatients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals", "DailyPainJournalId", cascadeDelete: true);
        }
    }
}
