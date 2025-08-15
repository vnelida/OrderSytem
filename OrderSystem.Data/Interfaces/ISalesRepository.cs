using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
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
        List<SaleDetail> GetSaleDetailsBySaleId(int saleId, SqlConnection conn, SqlTransaction tran);
        List<SalesListDto> GetSalesListt(SqlConnection conn, int currentPage, int pageSize, OrderTypes? orderType = null, OrderStatuses? status = null, Order? order = null, SqlTransaction? tran = null);
        int GetSalesCountt(SqlConnection conn, OrderTypes? orderType = null, OrderStatuses? status = null, SqlTransaction? tran = null);
        void UpdateSaleStatus(int saleId, int cancelled, SqlConnection conn, SqlTransaction tran);
    }
}
