namespace Entities.Entities
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public override string ToString()
        {
            return $"{PhoneNumber ?? "N/A"}";
        }
    }
}
