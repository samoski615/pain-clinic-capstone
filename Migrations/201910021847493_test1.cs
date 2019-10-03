namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "StatesDictionaryId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "StatesDictionaryId");
        }
    }
}
