namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "PatientBalance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "PatientBalance");
        }
    }
}
