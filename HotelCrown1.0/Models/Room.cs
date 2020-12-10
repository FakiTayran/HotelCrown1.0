using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    [Table("Rooms")]
    public class Room
    {
        public Room()
        {
            Features = new HashSet<Feature>();
            Reservations = new HashSet<Reservation>();
            Customers = new HashSet<Customer>();
        }
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string RoomName { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public string FeaturesNames { get { return $"Features of this room : TV, Bathroom, Mini Bar, Towel,Slipper,Hair Dryer,{Features.Select(x => x.FeatureName).Virgulle()}"; }}
        public virtual ICollection<Feature> Features  { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public override string ToString()
        {
            return RoomName;
        }
    }
}
