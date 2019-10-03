namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "StatesDictionaryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "StatesDictionaryId", c => c.Int());
        }
    }
}
