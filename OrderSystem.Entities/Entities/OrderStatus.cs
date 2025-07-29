using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string StatusName { get; set; } = null!;

        // propiedad de navegación inversa para ver las ventas de un estado
        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
