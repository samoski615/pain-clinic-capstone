namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressesId = c.Int(nullable: false, identity: true),
                        ClinicName = c.String(),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zipcode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AddressesId);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        ClinicId = c.Int(nullable: false, identity: true),
                        AddressesId = c.Int(),
                    })
                .PrimaryKey(t => t.ClinicId)
                .ForeignKey("dbo.Addresses", t => t.AddressesId)
                .Index(t => t.AddressesId);
            
            CreateTable(
                "dbo.DailyLogs",
                c => new
                    {
                        DailyLogId = c.Int(nullable: false, identity: true),
                        TodaysDate = c.DateTime(nullable: false),
                        PainRating_DataGroupField = c.String(),
                        PainRating_DataTextField = c.String(),
                        PainRating_DataValueField = c.String(),
                        PainLocation_DataGroupField = c.String(),
                        PainLocation_DataTextField = c.String(),
                        PainLocation_DataValueField = c.String(),
                        AmountOfSleep_DataGroupField = c.String(),
                        AmountOfSleep_DataTextField = c.String(),
                        AmountOfSleep_DataValueField = c.String(),
                        ActivityLevel_DataGroupField = c.String(),
                        ActivityLevel_DataTextField = c.String(),
                        ActivityLevel_DataValueField = c.String(),
                        DailyActivities = c.String(),
                    })
                .PrimaryKey(t => t.DailyLogId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Guid(nullable: false),
                        ClinicId = c.Int(),
                        AddressesId = c.Int(),
                        DailyLogId = c.Int(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        RxReceived = c.Boolean(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Addresses", t => t.AddressesId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .ForeignKey("dbo.Clinics", t => t.ClinicId)
                .ForeignKey("dbo.DailyLogs", t => t.DailyLogId)
                .Index(t => t.ClinicId)
                .Index(t => t.AddressesId)
                .Index(t => t.DailyLogId)
                .Index(t => t.ApplicationId);
            
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
                "dbo.Providers",
                c => new
                    {
                        ProviderId = c.Guid(nullable: false),
                        ClinicId = c.Int(),
                        Prefix = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        RxReceived = c.Boolean(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProviderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .ForeignKey("dbo.Clinics", t => t.ClinicId)
                .Index(t => t.ClinicId)
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
            
            CreateTable(
                "dbo.ProviderPatients",
                c => new
                    {
                        Provider_ProviderId = c.Guid(nullable: false),
                        Patient_PatientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_ProviderId, t.Patient_PatientId })
                .ForeignKey("dbo.Providers", t => t.Provider_ProviderId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId, cascadeDelete: true)
                .Index(t => t.Provider_ProviderId)
                .Index(t => t.Patient_PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProviderPatients", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.ProviderPatients", "Provider_ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Providers", "ClinicId", "dbo.Clinics");
            DropForeignKey("dbo.Providers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patients", "DailyLogId", "dbo.DailyLogs");
            DropForeignKey("dbo.Patients", "ClinicId", "dbo.Clinics");
            DropForeignKey("dbo.Patients", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patients", "AddressesId", "dbo.Addresses");
            DropForeignKey("dbo.Clinics", "AddressesId", "dbo.Addresses");
            DropIndex("dbo.ProviderPatients", new[] { "Patient_PatientId" });
            DropIndex("dbo.ProviderPatients", new[] { "Provider_ProviderId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Providers", new[] { "ApplicationId" });
            DropIndex("dbo.Providers", new[] { "ClinicId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Patients", new[] { "ApplicationId" });
            DropIndex("dbo.Patients", new[] { "DailyLogId" });
            DropIndex("dbo.Patients", new[] { "AddressesId" });
            DropIndex("dbo.Patients", new[] { "ClinicId" });
            DropIndex("dbo.Clinics", new[] { "AddressesId" });
            DropTable("dbo.ProviderPatients");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Providers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Patients");
            DropTable("dbo.DailyLogs");
            DropTable("dbo.Clinics");
            DropTable("dbo.Addresses");
        }
    }
}
