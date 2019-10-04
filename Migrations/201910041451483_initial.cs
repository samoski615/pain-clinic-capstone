namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressesId = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                    })
                .PrimaryKey(t => t.AddressesId);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        ClinicId = c.Int(nullable: false, identity: true),
                        AddressesId = c.Int(),
                        ClinicName = c.String(),
                    })
                .PrimaryKey(t => t.ClinicId)
                .ForeignKey("dbo.Addresses", t => t.AddressesId)
                .Index(t => t.AddressesId);
            
            CreateTable(
                "dbo.DailyPainJournals",
                c => new
                    {
                        DailyPainJournalId = c.Int(nullable: false, identity: true),
                        PainRating = c.String(nullable: false),
                        PainLocation = c.String(nullable: false),
                        AmountOfSleep = c.String(nullable: false),
                        ActivityLevel = c.String(nullable: false),
                        SearchDate = c.DateTime(nullable: false),
                        PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.DailyPainJournalId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        RxRequested = c.Boolean(),
                        RxFilled = c.Boolean(),
                        PatientBalance = c.Double(),
                        ApplicationId = c.String(maxLength: 128),
                        AddressesId = c.Int(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Addresses", t => t.AddressesId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId)
                .Index(t => t.AddressesId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PatientPainDatas",
                c => new
                    {
                        PatientPainDataId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PatientPainDataId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ProviderId = c.Int(nullable: false, identity: true),
                        Prefix = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        RxRequested = c.Boolean(),
                        RxFilled = c.Boolean(),
                        PatientBalance = c.Double(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProviderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Providers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DailyPainJournals", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patients", "AddressesId", "dbo.Addresses");
            DropForeignKey("dbo.Clinics", "AddressesId", "dbo.Addresses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Providers", new[] { "ApplicationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Patients", new[] { "AddressesId" });
            DropIndex("dbo.Patients", new[] { "ApplicationId" });
            DropIndex("dbo.DailyPainJournals", new[] { "PatientId" });
            DropIndex("dbo.Clinics", new[] { "AddressesId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Providers");
            DropTable("dbo.PatientPainDatas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Patients");
            DropTable("dbo.DailyPainJournals");
            DropTable("dbo.Clinics");
            DropTable("dbo.Addresses");
        }
    }
}
