using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    [Table("Features")]
    public class Feature
    {
        public Feature()
        {
            Rooms = new HashSet<Room>();
        }
        public int Id { get; set; }

        [Required,MaxLength(200)]
        public string FeatureName { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public override string ToString()
        {
            return FeatureName; 
        }
    }
}
