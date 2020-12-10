using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    [Table("ServiceDetails")]
    public class ServiceDetail
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
      
        public int ServiceId { get; set; }

        [Required,MaxLength(200)]
        public string ServiceName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get { return CalculateTotalAmount();} }

        public virtual Reservation Reservation { get; set; }

        public virtual Service Service { get; set; }

        public string ServiceAndQuantity { get { return ServiceName + " ( X " + Quantity + ") "; } }
        public decimal CalculateTotalAmount() => UnitPrice * Quantity;

    }
}
