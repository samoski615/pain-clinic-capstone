namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaPatientFKtoAddressesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "AddressesId", "dbo.Addresses");
            DropIndex("dbo.Patients", new[] { "AddressesId" });
            AddColumn("dbo.Addresses", "PatientId", c => c.Int());
            AddColumn("dbo.Addresses", "Patient_PatientId", c => c.Int());
            AddColumn("dbo.Patients", "Addresses_AddressesId", c => c.Int());
            AddColumn("dbo.Patients", "Addresses_AddressesId1", c => c.Int());
            CreateIndex("dbo.Addresses", "Patient_PatientId");
            CreateIndex("dbo.Patients", "Addresses_AddressesId");
            CreateIndex("dbo.Patients", "Addresses_AddressesId1");
            AddForeignKey("dbo.Addresses", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Patients", "Addresses_AddressesId1", "dbo.Addresses", "AddressesId");
            AddForeignKey("dbo.Patients", "Addresses_AddressesId", "dbo.Addresses", "AddressesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Addresses_AddressesId", "dbo.Addresses");
            DropForeignKey("dbo.Patients", "Addresses_AddressesId1", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.Patients", new[] { "Addresses_AddressesId1" });
            DropIndex("dbo.Patients", new[] { "Addresses_AddressesId" });
            DropIndex("dbo.Addresses", new[] { "Patient_PatientId" });
            DropColumn("dbo.Patients", "Addresses_AddressesId1");
            DropColumn("dbo.Patients", "Addresses_AddressesId");
            DropColumn("dbo.Addresses", "Patient_PatientId");
            DropColumn("dbo.Addresses", "PatientId");
            CreateIndex("dbo.Patients", "AddressesId");
            AddForeignKey("dbo.Patients", "AddressesId", "dbo.Addresses", "AddressesId");
        }
    }
}
