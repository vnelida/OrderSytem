using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class SalesListDto
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public bool IsGift { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Customer { get; set; }
    }
}
