namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Providers", "PatientBalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "PatientBalance", c => c.Double(nullable: false));
        }
    }
}
