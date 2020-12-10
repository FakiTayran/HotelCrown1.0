namespace HotelCrown1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyConflict : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "Service_Id", "dbo.Services");
            DropIndex("dbo.Reservations", new[] { "Service_Id" });
            DropColumn("dbo.Reservations", "Service_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Service_Id", c => c.Int());
            CreateIndex("dbo.Reservations", "Service_Id");
            AddForeignKey("dbo.Reservations", "Service_Id", "dbo.Services", "Id");
        }
    }
}
