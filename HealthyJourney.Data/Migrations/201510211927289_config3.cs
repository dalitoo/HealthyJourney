namespace HealthyJourney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class config3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Badges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalCenterMetadatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        file = c.String(),
                        MedicalCenter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalCenters", t => t.MedicalCenter_Id)
                .Index(t => t.MedicalCenter_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 8),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 8),
                        IsApproved = c.Boolean(nullable: false),
                        Thumbnail = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Adress_City = c.String(),
                        Adress_Street = c.String(),
                        Adress_Postal = c.String(),
                        Adress_Longitude = c.String(),
                        Adress_Latitude = c.String(),
                        Discriminator = c.String(maxLength: 128),
                        badge_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Badges", t => t.badge_Id)
                .Index(t => t.badge_Id);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Client_Id = c.Int(),
                        speciality_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Specialities", t => t.speciality_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.speciality_Id);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceProviderBadges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateObtention = c.DateTime(nullable: false),
                        Badge_Id = c.Int(),
                        ServiceProvider_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Badges", t => t.Badge_Id)
                .ForeignKey("dbo.Users", t => t.ServiceProvider_Id)
                .Index(t => t.Badge_Id)
                .Index(t => t.ServiceProvider_Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Age = c.Int(nullable: false),
                        Country = c.String(),
                        Language = c.String(),
                        Currency = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MedicalCenters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Id", "dbo.Users");
            DropForeignKey("dbo.Insurances", "Id", "dbo.Users");
            DropForeignKey("dbo.MedicalCenters", "Id", "dbo.Users");
            DropForeignKey("dbo.Clients", "Id", "dbo.Users");
            DropForeignKey("dbo.Consultants", "Id", "dbo.Users");
            DropForeignKey("dbo.Admins", "Id", "dbo.Users");
            DropForeignKey("dbo.ServiceProviderBadges", "ServiceProvider_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "badge_Id", "dbo.Badges");
            DropForeignKey("dbo.ServiceProviderBadges", "Badge_Id", "dbo.Badges");
            DropForeignKey("dbo.MedicalRecords", "speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.MedicalRecords", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.MedicalCenterMetadatas", "MedicalCenter_Id", "dbo.MedicalCenters");
            DropIndex("dbo.Doctors", new[] { "Id" });
            DropIndex("dbo.Insurances", new[] { "Id" });
            DropIndex("dbo.MedicalCenters", new[] { "Id" });
            DropIndex("dbo.Clients", new[] { "Id" });
            DropIndex("dbo.Consultants", new[] { "Id" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropIndex("dbo.ServiceProviderBadges", new[] { "ServiceProvider_Id" });
            DropIndex("dbo.ServiceProviderBadges", new[] { "Badge_Id" });
            DropIndex("dbo.MedicalRecords", new[] { "speciality_Id" });
            DropIndex("dbo.MedicalRecords", new[] { "Client_Id" });
            DropIndex("dbo.Users", new[] { "badge_Id" });
            DropIndex("dbo.MedicalCenterMetadatas", new[] { "MedicalCenter_Id" });
            DropTable("dbo.Doctors");
            DropTable("dbo.Insurances");
            DropTable("dbo.MedicalCenters");
            DropTable("dbo.Clients");
            DropTable("dbo.Consultants");
            DropTable("dbo.Admins");
            DropTable("dbo.ServiceProviderBadges");
            DropTable("dbo.Specialities");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Users");
            DropTable("dbo.MedicalCenterMetadatas");
            DropTable("dbo.Badges");
        }
    }
}
