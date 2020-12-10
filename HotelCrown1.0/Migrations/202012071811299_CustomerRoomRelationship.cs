namespace HotelCrown1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerRoomRelationship : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoomFeature1", newName: "FeatureRooms");
            DropPrimaryKey("dbo.FeatureRooms");
            AddColumn("dbo.Customers", "RoomId", c => c.Int());
            AddPrimaryKey("dbo.FeatureRooms", new[] { "Feature_Id", "Room_Id" });
            CreateIndex("dbo.Customers", "RoomId");
            AddForeignKey("dbo.Customers", "RoomId", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Customers", new[] { "RoomId" });
            DropPrimaryKey("dbo.FeatureRooms");
            DropColumn("dbo.Customers", "RoomId");
            AddPrimaryKey("dbo.FeatureRooms", new[] { "Room_Id", "Feature_Id" });
            RenameTable(name: "dbo.FeatureRooms", newName: "RoomFeature1");
        }
    }
}
