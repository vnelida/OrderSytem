namespace Entities.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Phone { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? Dni { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

    }
}
