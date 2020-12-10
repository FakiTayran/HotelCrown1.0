namespace HotelCrown1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerReservationAdded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "Reservation_Id", newName: "ReservationId");
            RenameIndex(table: "dbo.Customers", name: "IX_Reservation_Id", newName: "IX_ReservationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_ReservationId", newName: "IX_Reservation_Id");
            RenameColumn(table: "dbo.Customers", name: "ReservationId", newName: "Reservation_Id");
        }
    }
}
