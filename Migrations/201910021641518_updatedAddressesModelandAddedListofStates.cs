namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAddressesModelandAddedListofStates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "State_DataGroupField", c => c.String());
            AddColumn("dbo.Addresses", "State_DataTextField", c => c.String());
            AddColumn("dbo.Addresses", "State_DataValueField", c => c.String());
            DropColumn("dbo.Addresses", "State");
            DropColumn("dbo.Addresses", "Latitude");
            DropColumn("dbo.Addresses", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Addresses", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Addresses", "State", c => c.String());
            DropColumn("dbo.Addresses", "State_DataValueField");
            DropColumn("dbo.Addresses", "State_DataTextField");
            DropColumn("dbo.Addresses", "State_DataGroupField");
        }
    }
}
