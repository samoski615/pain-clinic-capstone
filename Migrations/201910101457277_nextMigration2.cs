namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        PrescriptionId = c.Int(nullable: false, identity: true),
                        RxName = c.String(),
                        RxStrength = c.String(),
                        RxDose = c.String(),
                        PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.PrescriptionId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            DropColumn("dbo.Patients", "RxName");
            DropColumn("dbo.Patients", "RxStrength");
            DropColumn("dbo.Patients", "RxDose");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "RxDose", c => c.String());
            AddColumn("dbo.Patients", "RxStrength", c => c.String());
            AddColumn("dbo.Patients", "RxName", c => c.String());
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropTable("dbo.Prescriptions");
        }
    }
}
