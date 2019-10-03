namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals");
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId1", "dbo.Patients");
            DropIndex("dbo.Patients", new[] { "DailyPainJournal_DailyPainJournalId" });
            DropIndex("dbo.DailyPainJournals", new[] { "Patient_PatientId" });
            DropIndex("dbo.DailyPainJournals", new[] { "Patient_PatientId1" });
            CreateTable(
                "dbo.DailyPainJournalPatients",
                c => new
                    {
                        DailyPainJournal_DailyPainJournalId = c.Int(nullable: false),
                        Patient_PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DailyPainJournal_DailyPainJournalId, t.Patient_PatientId })
                .ForeignKey("dbo.DailyPainJournals", t => t.DailyPainJournal_DailyPainJournalId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId, cascadeDelete: true)
                .Index(t => t.DailyPainJournal_DailyPainJournalId)
                .Index(t => t.Patient_PatientId);
            
            DropColumn("dbo.Patients", "DailyPainJournal_DailyPainJournalId");
            DropColumn("dbo.DailyPainJournals", "SearchDateStart");
            DropColumn("dbo.DailyPainJournals", "SearchDateEnd");
            DropColumn("dbo.DailyPainJournals", "PatientId");
            DropColumn("dbo.DailyPainJournals", "Patient_PatientId");
            DropColumn("dbo.DailyPainJournals", "Patient_PatientId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DailyPainJournals", "Patient_PatientId1", c => c.Int());
            AddColumn("dbo.DailyPainJournals", "Patient_PatientId", c => c.Int());
            AddColumn("dbo.DailyPainJournals", "PatientId", c => c.Int());
            AddColumn("dbo.DailyPainJournals", "SearchDateEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.DailyPainJournals", "SearchDateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patients", "DailyPainJournal_DailyPainJournalId", c => c.Int());
            DropForeignKey("dbo.DailyPainJournalPatients", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.DailyPainJournalPatients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals");
            DropIndex("dbo.DailyPainJournalPatients", new[] { "Patient_PatientId" });
            DropIndex("dbo.DailyPainJournalPatients", new[] { "DailyPainJournal_DailyPainJournalId" });
            DropTable("dbo.DailyPainJournalPatients");
            CreateIndex("dbo.DailyPainJournals", "Patient_PatientId1");
            CreateIndex("dbo.DailyPainJournals", "Patient_PatientId");
            CreateIndex("dbo.Patients", "DailyPainJournal_DailyPainJournalId");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId1", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Patients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals", "DailyPainJournalId");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
    }
}
