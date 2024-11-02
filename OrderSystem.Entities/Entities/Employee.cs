using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public int? Phone { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Address { get; set; } = null;

    }
}
