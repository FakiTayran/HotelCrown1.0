using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    public class HotelCrownContext :DbContext
    {
        public HotelCrownContext() :base("name=HotelCrownContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ServiceDetail>()
                .HasRequired(x => x.Service)
                .WithMany(x => x.ServiceDetails)
                .HasForeignKey(x => x.ServiceId)
                .WillCascadeOnDelete(false);
            modelBuilder
                .Entity<ServiceDetail>()
                .HasRequired(x => x.Reservation)
                .WithMany(x => x.ServiceDetails)
                .HasForeignKey(x => x.ReservationId)
                .WillCascadeOnDelete(false);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet <Feature>Features { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet <Reservation>Reservations { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }

        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<ReservationCustomer> ReservationCustomers { get; set; }

    }
}
