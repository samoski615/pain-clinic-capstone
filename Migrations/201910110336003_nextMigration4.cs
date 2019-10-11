namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "IsRxRequested", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "IsRxFilled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Providers", "IsRxRequested", c => c.Boolean(nullable: false));
            AddColumn("dbo.Providers", "IsRxFilled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Patients", "PatientBalance", c => c.Double(nullable: true));
            AlterColumn("dbo.Providers", "PatientBalance", c => c.Double(nullable: true));
            DropColumn("dbo.Patients", "RxRequested");
            DropColumn("dbo.Patients", "RxFilled");
            DropColumn("dbo.Providers", "RxRequested");
            DropColumn("dbo.Providers", "RxFilled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "RxFilled", c => c.Boolean());
            AddColumn("dbo.Providers", "RxRequested", c => c.Boolean());
            AddColumn("dbo.Patients", "RxFilled", c => c.Boolean());
            AddColumn("dbo.Patients", "RxRequested", c => c.Boolean());
            AlterColumn("dbo.Providers", "PatientBalance", c => c.Double());
            AlterColumn("dbo.Patients", "PatientBalance", c => c.Double());
            DropColumn("dbo.Providers", "IsRxFilled");
            DropColumn("dbo.Providers", "IsRxRequested");
            DropColumn("dbo.Patients", "IsRxFilled");
            DropColumn("dbo.Patients", "IsRxRequested");
        }
    }
}
