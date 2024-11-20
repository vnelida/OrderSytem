using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ISalesRepository
    {
        void Add(Sale sale, SqlConnection conn, SqlTransaction tran);
        void Edit(Sale sale, SqlConnection conn, SqlTransaction tran);
        int GetCaount(SqlConnection conn, Func<SalesListDto, bool>? filter);
        List<SalesListDto> GetList(SqlConnection conn, int currentPage, int pageSize, Func<SalesListDto, bool>? filter = null, SqlTransaction? tran = null);
        Sale? GetSaleById(SqlConnection conn, int saleId, SqlTransaction? tran = null);
    }
}
