namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPatientsFKtoDailyPainJournal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientPainDatas", "DailyLog_DailyPainJournalId", "dbo.DailyPainJournals");
            DropIndex("dbo.DailyPainJournals", new[] { "Patient_PatientId" });
            DropIndex("dbo.PatientPainDatas", new[] { "DailyLog_DailyPainJournalId" });
            RenameColumn(table: "dbo.PatientPainDatas", name: "DailyLog_DailyPainJournalId", newName: "DailyPainJournalId");
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
            
            AlterColumn("dbo.PatientPainDatas", "DailyPainJournalId", c => c.Int(nullable: false));
            CreateIndex("dbo.PatientPainDatas", "DailyPainJournalId");
            AddForeignKey("dbo.PatientPainDatas", "DailyPainJournalId", "dbo.DailyPainJournals", "DailyPainJournalId", cascadeDelete: true);
            DropColumn("dbo.DailyPainJournals", "Patient_PatientId");
            DropColumn("dbo.PatientPainDatas", "DailyLogId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientPainDatas", "DailyLogId", c => c.Int(nullable: false));
            AddColumn("dbo.DailyPainJournals", "Patient_PatientId", c => c.Int());
            DropForeignKey("dbo.PatientPainDatas", "DailyPainJournalId", "dbo.DailyPainJournals");
            DropForeignKey("dbo.DailyPainJournalPatients", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.DailyPainJournalPatients", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals");
            DropIndex("dbo.DailyPainJournalPatients", new[] { "Patient_PatientId" });
            DropIndex("dbo.DailyPainJournalPatients", new[] { "DailyPainJournal_DailyPainJournalId" });
            DropIndex("dbo.PatientPainDatas", new[] { "DailyPainJournalId" });
            AlterColumn("dbo.PatientPainDatas", "DailyPainJournalId", c => c.Int());
            DropTable("dbo.DailyPainJournalPatients");
            RenameColumn(table: "dbo.PatientPainDatas", name: "DailyPainJournalId", newName: "DailyLog_DailyPainJournalId");
            CreateIndex("dbo.PatientPainDatas", "DailyLog_DailyPainJournalId");
            CreateIndex("dbo.DailyPainJournals", "Patient_PatientId");
            AddForeignKey("dbo.PatientPainDatas", "DailyLog_DailyPainJournalId", "dbo.DailyPainJournals", "DailyPainJournalId");
            AddForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
    }
}
