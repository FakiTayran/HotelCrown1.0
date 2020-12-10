using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    [Table("RoomFeatures")]
    public class RoomFeature
    {
        [Key,Column(Order = 0 )]
        [ForeignKey("Room")]
        public int RoomId { get; set; }

        [Key,Column(Order = 1)]
        [ForeignKey("Feature")]
        public int FeatureId { get; set; }

        public virtual Room Room { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
