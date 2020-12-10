using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown1._0.Models
{
    [Table("Services")]
    public class Service
    {
        public Service()
        {
            ServiceDetails = new HashSet<ServiceDetail>();
        }
        public int Id { get; set; }

        [Required,MaxLength(200)]
        public string ServiceName { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }

        public override string ToString()
        {
            return ServiceName;
        }
    }
}
