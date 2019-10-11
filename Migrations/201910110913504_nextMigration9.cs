namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMigration9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        MapReference = c.String(),
                        CountryCode = c.String(),
                        CountryCodeLong = c.String(),
                        Venue_VenueId = c.Int(),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Venues", t => t.Venue_VenueId)
                .Index(t => t.Venue_VenueId);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        CountryName = c.String(),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        CountryCode = c.String(),
                    })
                .PrimaryKey(t => t.VenueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "Venue_VenueId", "dbo.Venues");
            DropIndex("dbo.Countries", new[] { "Venue_VenueId" });
            DropTable("dbo.Venues");
            DropTable("dbo.Countries");
        }
    }
}
