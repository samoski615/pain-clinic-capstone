namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "RxName", c => c.String());
            AddColumn("dbo.Patients", "RxStrength", c => c.String());
            AddColumn("dbo.Patients", "RxDose", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "RxDose");
            DropColumn("dbo.Patients", "RxStrength");
            DropColumn("dbo.Patients", "RxName");
        }
    }
}
