namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "PatientBalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "PatientBalance", c => c.Double(nullable: false));
        }
    }
}
