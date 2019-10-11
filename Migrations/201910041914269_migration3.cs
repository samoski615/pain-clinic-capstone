namespace PainClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PatientPainDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PatientPainDatas",
                c => new
                    {
                        PatientPainDataId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PatientPainDataId);
            
        }
    }
}
