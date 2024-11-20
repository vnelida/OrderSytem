namespace Entities.Dtos
{
    public class CustomerListDto
    {
        public int CustomerId { get; set; }
        public int DocumentNumber { get; set; }
        public string? FullName { get; set; }
        public string? PrincipalAddress { get; set; }
        public string? PrincipalPhone { get; set; }
    }
}
