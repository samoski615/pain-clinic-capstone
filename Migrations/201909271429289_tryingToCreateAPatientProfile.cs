namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToCreateAPatientProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "ClinicId", "dbo.Clinics");
            DropIndex("dbo.Patients", new[] { "ClinicId" });
            DropColumn("dbo.Patients", "ClinicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "ClinicId", c => c.Int());
            CreateIndex("dbo.Patients", "ClinicId");
            AddForeignKey("dbo.Patients", "ClinicId", "dbo.Clinics", "ClinicId");
        }
    }
}
