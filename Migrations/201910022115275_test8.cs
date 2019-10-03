namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DailyPainJournalPatients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals");
            DropForeignKey("dbo.DailyPainJournalPatients", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.DailyPainJournalPatients", new[] { "DailyPainJournal_DailyPainJournalId" });
            DropIndex("dbo.DailyPainJournalPatients", new[] { "Patient_PatientId" });
            AddColumn("dbo.Patients", "DailyPainJournalId", c => c.Int());
            AddColumn("dbo.Patients", "DailyPainJournal_DailyPainJournalId", c => c.Int());
            AddColumn("dbo.Patients", "DailyPainJournals_DailyPainJournalId", c => c.Int());
            AddColumn("dbo.DailyPainJournals", "Patient_PatientId", c => c.Int());
            CreateIndex("dbo.Patients", "DailyPainJournal_DailyPainJournalId");
            CreateIndex("dbo.Patients", "DailyPainJournals_DailyPainJournalId");
            CreateIndex("dbo.DailyPainJournals", "Patient_PatientId");
            AddForeignKey("dbo.Patients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals", "DailyPainJournalId");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Patients", "DailyPainJournals_DailyPainJournalId", "dbo.DailyPainJournals", "DailyPainJournalId");
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
            
            DropForeignKey("dbo.Patients", "DailyPainJournals_DailyPainJournalId", "dbo.DailyPainJournals");
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals");
            DropIndex("dbo.DailyPainJournals", new[] { "Patient_PatientId" });
            DropIndex("dbo.Patients", new[] { "DailyPainJournals_DailyPainJournalId" });
            DropIndex("dbo.Patients", new[] { "DailyPainJournal_DailyPainJournalId" });
            DropColumn("dbo.DailyPainJournals", "Patient_PatientId");
            DropColumn("dbo.Patients", "DailyPainJournals_DailyPainJournalId");
            DropColumn("dbo.Patients", "DailyPainJournal_DailyPainJournalId");
            DropColumn("dbo.Patients", "DailyPainJournalId");
            CreateIndex("dbo.DailyPainJournalPatients", "Patient_PatientId");
            CreateIndex("dbo.DailyPainJournalPatients", "DailyPainJournal_DailyPainJournalId");
            AddForeignKey("dbo.DailyPainJournalPatients", "Patient_PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.DailyPainJournalPatients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals", "DailyPainJournalId", cascadeDelete: true);
        }
    }
}
