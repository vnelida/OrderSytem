using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CustomerDetailsDto
    {
        public int CustomerId { get; set; }
        public int DocumentNumber { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;

        // Relaciones
        public List<AddressListDto> Addresses { get; set; } = new List<AddressListDto>();
        public List<PhoneListDto> Phones { get; set; } = new List<PhoneListDto>();
    }
}
