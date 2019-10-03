namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAddressesProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "State", c => c.String());
            DropColumn("dbo.Addresses", "State_DataGroupField");
            DropColumn("dbo.Addresses", "State_DataTextField");
            DropColumn("dbo.Addresses", "State_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "State_DataValueField", c => c.String());
            AddColumn("dbo.Addresses", "State_DataTextField", c => c.String());
            AddColumn("dbo.Addresses", "State_DataGroupField", c => c.String());
            DropColumn("dbo.Addresses", "State");
        }
    }
}
