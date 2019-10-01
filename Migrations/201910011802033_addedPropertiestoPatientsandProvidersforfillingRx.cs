namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPropertiestoPatientsandProvidersforfillingRx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "RxRequested", c => c.Boolean());
            AddColumn("dbo.Patients", "RxFilled", c => c.Boolean());
            AddColumn("dbo.Providers", "RxRequested", c => c.Boolean());
            AddColumn("dbo.Providers", "RxFilled", c => c.Boolean());
            DropColumn("dbo.Patients", "RxReceived");
            DropColumn("dbo.Providers", "RxReceived");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "RxReceived", c => c.Boolean());
            AddColumn("dbo.Patients", "RxReceived", c => c.Boolean());
            DropColumn("dbo.Providers", "RxFilled");
            DropColumn("dbo.Providers", "RxRequested");
            DropColumn("dbo.Patients", "RxFilled");
            DropColumn("dbo.Patients", "RxRequested");
        }
    }
}
