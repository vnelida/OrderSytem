using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int DocumentNumber { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;

        public string FullName { get => $"{LastName} {FirstName}"; }
        
        public List<CustomerAddress> CustomerAdresses { get; set; } = new List<CustomerAddress>();
        public List<CustomerPhone> CustomerPhones { get; set; } = new List<CustomerPhone>();
    }
}
