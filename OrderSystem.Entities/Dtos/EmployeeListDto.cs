using Entities.Entities;

namespace Entities.Dtos
{
    public class EmployeeListDto
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Phone { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? Dni { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? GenreName { get; set; }

    }
}
