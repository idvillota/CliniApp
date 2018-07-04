namespace ClinicApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CitaTypeID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CitaTypes", t => t.CitaTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.CitaTypeID)
                .Index(t => t.DoctorID)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.CitaTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentNumber = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentNumber = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        Birth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Citas", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Citas", "CitaTypeID", "dbo.CitaTypes");
            DropIndex("dbo.Citas", new[] { "PatientID" });
            DropIndex("dbo.Citas", new[] { "DoctorID" });
            DropIndex("dbo.Citas", new[] { "CitaTypeID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.CitaTypes");
            DropTable("dbo.Citas");
        }
    }
}
