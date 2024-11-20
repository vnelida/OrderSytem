using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class CustomerPhone
    {
        public int CustomerId { get; set; }
        public int PhoneId { get; set; }
        public int PhoneTypeId { get; set; }

        // Relaciones
        public Customer Customer { get; set; } = null!;
        public Phone Phone { get; set; } = null!;
        public PhoneType PhoneType { get; set; } = null!;
    }
}
