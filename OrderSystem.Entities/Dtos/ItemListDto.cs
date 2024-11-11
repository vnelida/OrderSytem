using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ItemListDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public bool Suspended { get; set; }
        public int ReorderLevel { get; set; }

    }
}
