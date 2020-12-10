using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    [Table("ReservationCustomers")]
    public class ReservationCustomer
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Reservation Reservation { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
