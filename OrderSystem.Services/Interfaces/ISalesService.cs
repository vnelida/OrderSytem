using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISalesService
    {
        int GetCount(Func<SalesListDto, bool>? filter);
        List<SalesListDto> GetList(int currentPage, int pageSize, Func<SalesListDto, bool>? filter = null);
        Sale? GetSaleById(int saleId);
        void Save(Sale? sale);
    }
}
