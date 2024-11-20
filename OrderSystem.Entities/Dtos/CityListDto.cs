using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CityListDto
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        public string? StateProvinceName { get; set; }
    }
}
