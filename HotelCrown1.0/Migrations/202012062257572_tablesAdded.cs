namespace HotelCrown1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        IdentityNumber = c.String(maxLength: 11),
                        PhoneNumber = c.String(maxLength: 15),
                        BirthDate = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        Description = c.String(),
                        Reservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .Index(t => t.Reservation_Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false, maxLength: 100),
                        Capacity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        RoomName = c.String(),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        CheckedInDate = c.DateTime(),
                        CheckedOutDate = c.DateTime(),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.RoomId)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.ServiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        ServiceName = c.String(nullable: false, maxLength: 200),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.ReservationId)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .Index(t => t.ReservationId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false, maxLength: 200),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservationCustomers",
                c => new
                    {
                        ReservationId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReservationId, t.CustomerId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.ReservationId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.RoomFeatures",
                c => new
                    {
                        RoomId = c.Int(nullable: false),
                        FeatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomId, t.FeatureId })
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.FeatureId);
            
            CreateTable(
                "dbo.RoomFeature1",
                c => new
                    {
                        Room_Id = c.Int(nullable: false),
                        Feature_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Id, t.Feature_Id })
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.Feature_Id, cascadeDelete: true)
                .Index(t => t.Room_Id)
                .Index(t => t.Feature_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomFeatures", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomFeatures", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.ReservationCustomers", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.ReservationCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ServiceDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Reservations", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.ServiceDetails", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Customers", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.RoomFeature1", "Feature_Id", "dbo.Features");
            DropForeignKey("dbo.RoomFeature1", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.RoomFeature1", new[] { "Feature_Id" });
            DropIndex("dbo.RoomFeature1", new[] { "Room_Id" });
            DropIndex("dbo.RoomFeatures", new[] { "FeatureId" });
            DropIndex("dbo.RoomFeatures", new[] { "RoomId" });
            DropIndex("dbo.ReservationCustomers", new[] { "CustomerId" });
            DropIndex("dbo.ReservationCustomers", new[] { "ReservationId" });
            DropIndex("dbo.ServiceDetails", new[] { "ServiceId" });
            DropIndex("dbo.ServiceDetails", new[] { "ReservationId" });
            DropIndex("dbo.Reservations", new[] { "Service_Id" });
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Customers", new[] { "Reservation_Id" });
            DropTable("dbo.RoomFeature1");
            DropTable("dbo.RoomFeatures");
            DropTable("dbo.ReservationCustomers");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceDetails");
            DropTable("dbo.Reservations");
            DropTable("dbo.Rooms");
            DropTable("dbo.Features");
            DropTable("dbo.Customers");
        }
    }
}
