using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string CustomerName { get; set; }

        [MaxLength(11)]
        public string IdentityNumber { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [ForeignKey("Reservation")]
        public int? ReservationId { get; set; }
        [ForeignKey("Room")]
        public int? RoomId { get; set; }

        public DateTime? BirthDate { get; set; }

        public GenderResult Gender { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return CustomerName;
        }

        public Reservation Reservation { get; set; }
        public Room Room { get; set; }
    }
}
