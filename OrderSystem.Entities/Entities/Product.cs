using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Product:Item
    {
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
