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
    public interface IStatesProvincesRepository
    {
        int GetCount(SqlConnection conn, Country? country = null, SqlTransaction? tran = null);
        void Add(StateProvince sp, SqlConnection conn, SqlTransaction? tran = null);
        void Delete(int stateProvinceId, SqlConnection conn, SqlTransaction? tran = null);
        void Edit(StateProvince sp, SqlConnection conn, SqlTransaction? tran = null);
        bool IsRelated(int stateProvinceId, SqlConnection conn, SqlTransaction? tran = null);
        bool Exist(StateProvince sp, SqlConnection conn, SqlTransaction? tran = null);


        List<StateProvinceListDto> GetList(SqlConnection conn, int? currentPage, int? pageSize, Order? order = Order.None, Country? country = null, SqlTransaction? tran = null);
        List<StateProvince> GetListComboStates(Country country, SqlConnection conn, SqlTransaction? tran = null);
        StateProvince? GetStateProvinceById(int stateProvinceId, SqlConnection conn, SqlTransaction? tran = null);
        int GetPageByRecord(SqlConnection conn, string stateProvinceName, int pageSize, SqlTransaction? tran = null);
    }
}
