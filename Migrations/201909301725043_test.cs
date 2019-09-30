namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Providers", "PatientBalance", c => c.Double());
            AlterColumn("dbo.Patients", "PatientBalance", c => c.Double());
            //DropColumn("dbo.Providers", "CustomerBalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "CustomerBalance", c => c.Double(nullable: false));
            AlterColumn("dbo.Patients", "PatientBalance", c => c.Double(nullable: false));
            //DropColumn("dbo.Providers", "PatientBalance");
        }
    }
}
