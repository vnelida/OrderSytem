using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public bool IsGift { get; set; }
        public decimal TotalAmount { get; set; }
        public SaleStatus Status { get; set; }
        public List<SaleDetails> Details { get; set; } = new List<SaleDetails>();
        public Customer? Customer { get; set; }

        public void Agregar(SaleDetails details)
        {
            var dEnVenta = Details.FirstOrDefault(
                x => x.ProductId == details.ProductId && x.ComboId == details.ComboId);
            if (dEnVenta == null)
            {
                Details.Add(details);
            }
            else
            {
                dEnVenta.Quantity += details.Quantity;
            }
        }
        public decimal GetTotal() => Details.Sum(dv => dv.Quantity * dv.Price);
        public int GetCantidad() => Details.Sum(dv => dv.Quantity);

        public void Borrar(SaleDetails dt)
        {
            Details.Remove(dt);
        }

    }
}
