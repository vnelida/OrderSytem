namespace Entities.Entities
{
    public class Combo : Item
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Size { get; set; } = null!;
        public List<ComboDetail> Details { get; set; } = new List<ComboDetail>();
        public void Add(ComboDetail detail)
        {
            var comboDetails = Details
                .FirstOrDefault(d => d.ProductId == detail.ProductId); //busca si ya existe este producto en el combo
            if (comboDetails is null)
            {
                Details.Add(detail);//si no existe, lo agrega
            }
            else
            {
                comboDetails.Quantity += detail.Quantity;//si existe, le agrega solo la cantidad
            }
        }
        public bool Exist(ComboDetail detail)
        {
            return Details.Any(d => d.ProductId == detail.ProductId);
        }

        public void Delete(ComboDetail detail)
        {
            Details.Remove(detail);
        }

    }
}
