using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; } = null!;

        // Relaciones
        public List<CustomerPhone> CustomerPhones { get; set; } = new List<CustomerPhone>();
        public override string ToString()
        {
            return $"{PhoneNumber}";
        }
    }
}
