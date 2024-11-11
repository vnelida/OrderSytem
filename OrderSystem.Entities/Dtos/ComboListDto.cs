namespace Entities.Dtos
{
    public class ComboListDto : ItemListDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Stock { get; set; }
        public string? Size { get; set; }
    }
}
