using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    [Table("Reservations")]
    public class Reservation
    {
        public Reservation()
        {
            Customers = new HashSet<Customer>();
            ServiceDetails = new HashSet<ServiceDetail>();
        }
        public int Id { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        public string RoomName { get; set; } 

        [Required]
        public DateTime? CheckInDate { get; set; }

        [Required]
        public DateTime? CheckOutDate { get; set; }
        public DateTime? CheckedInDate { get; set; }
        public DateTime? CheckedOutDate { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }

        public string CustomersName { get { return $"{Customers.Select(x => x.CustomerName.Substring(0,x.CustomerName.Length-Room.RoomName.Length-2)).Virgulle()}"; } } 

        public virtual ICollection <Customer> Customers { get; set; }

        public virtual Room Room { get; set; }
    }
}
