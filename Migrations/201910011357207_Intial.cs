namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
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
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
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
                "dbo.ClinicDirectories",
                c => new
                    {
                        ClinicDirectoryId = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        ClinicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClinicDirectoryId)
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .Index(t => t.ProviderId)
                .Index(t => t.PatientId)
                .Index(t => t.ClinicId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        RxReceived = c.Boolean(),
                        PatientBalance = c.Double(),
                        ApplicationId = c.String(maxLength: 128),
                        AddressesId = c.Int(),
                        PatientDataViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Addresses", t => t.AddressesId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .ForeignKey("dbo.PatientDataViewModels", t => t.PatientDataViewModel_Id)
                .Index(t => t.ApplicationId)
                .Index(t => t.AddressesId)
                .Index(t => t.PatientDataViewModel_Id);
            
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
                "dbo.DailyPainJournals",
                c => new
                    {
                        DailyPainJournalId = c.Int(nullable: false, identity: true),
                        TodaysDate = c.DateTime(nullable: false),
                        PainRating = c.String(),
                        PainLocation = c.String(),
                        AmountOfSleep = c.String(),
                        ActivityLevel = c.String(),
                        DailyActivities = c.String(),
                        Patient_PatientId = c.Int(),
                        PatientDataViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.DailyPainJournalId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .ForeignKey("dbo.PatientDataViewModels", t => t.PatientDataViewModel_Id)
                .Index(t => t.Patient_PatientId)
                .Index(t => t.PatientDataViewModel_Id);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ProviderId = c.Int(nullable: false, identity: true),
                        Prefix = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        RxReceived = c.Boolean(),
                        PatientBalance = c.Double(),
                        ApplicationId = c.String(maxLength: 128),
                        PatientDataVM_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ProviderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .ForeignKey("dbo.PatientDataViewModels", t => t.PatientDataVM_Id)
                .Index(t => t.ApplicationId)
                .Index(t => t.PatientDataVM_Id);
            
            CreateTable(
                "dbo.PatientDataViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DailyPainJournal_DailyPainJournalId = c.Int(),
                        Patient_PatientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DailyPainJournals", t => t.DailyPainJournal_DailyPainJournalId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.DailyPainJournal_DailyPainJournalId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.PatientPainDatas",
                c => new
                    {
                        PatientPainDataId = c.Int(nullable: false, identity: true),
                        DailyLogId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DailyLog_DailyPainJournalId = c.Int(),
                    })
                .PrimaryKey(t => t.PatientPainDataId)
                .ForeignKey("dbo.DailyPainJournals", t => t.DailyLog_DailyPainJournalId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DailyLog_DailyPainJournalId);
            
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
            DropForeignKey("dbo.PatientPainDatas", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientPainDatas", "DailyLog_DailyPainJournalId", "dbo.DailyPainJournals");
            DropForeignKey("dbo.Providers", "PatientDataVM_Id", "dbo.PatientDataViewModels");
            DropForeignKey("dbo.Patients", "PatientDataViewModel_Id", "dbo.PatientDataViewModels");
            DropForeignKey("dbo.PatientDataViewModels", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.DailyPainJournals", "PatientDataViewModel_Id", "dbo.PatientDataViewModels");
            DropForeignKey("dbo.PatientDataViewModels", "DailyPainJournal_DailyPainJournalId", "dbo.DailyPainJournals");
            DropForeignKey("dbo.ClinicDirectories", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Providers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DailyPainJournals", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.ClinicDirectories", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patients", "AddressesId", "dbo.Addresses");
            DropForeignKey("dbo.ClinicDirectories", "ClinicId", "dbo.Clinics");
            DropForeignKey("dbo.Clinics", "AddressesId", "dbo.Addresses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PatientPainDatas", new[] { "DailyLog_DailyPainJournalId" });
            DropIndex("dbo.PatientPainDatas", new[] { "PatientId" });
            DropIndex("dbo.PatientDataViewModels", new[] { "Patient_PatientId" });
            DropIndex("dbo.PatientDataViewModels", new[] { "DailyPainJournal_DailyPainJournalId" });
            DropIndex("dbo.Providers", new[] { "PatientDataVM_Id" });
            DropIndex("dbo.Providers", new[] { "ApplicationId" });
            DropIndex("dbo.DailyPainJournals", new[] { "PatientDataViewModel_Id" });
            DropIndex("dbo.DailyPainJournals", new[] { "Patient_PatientId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Patients", new[] { "PatientDataViewModel_Id" });
            DropIndex("dbo.Patients", new[] { "AddressesId" });
            DropIndex("dbo.Patients", new[] { "ApplicationId" });
            DropIndex("dbo.ClinicDirectories", new[] { "ClinicId" });
            DropIndex("dbo.ClinicDirectories", new[] { "PatientId" });
            DropIndex("dbo.ClinicDirectories", new[] { "ProviderId" });
            DropIndex("dbo.Clinics", new[] { "AddressesId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PatientPainDatas");
            DropTable("dbo.PatientDataViewModels");
            DropTable("dbo.Providers");
            DropTable("dbo.DailyPainJournals");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Patients");
            DropTable("dbo.ClinicDirectories");
            DropTable("dbo.Clinics");
            DropTable("dbo.Addresses");
        }
    }
}
