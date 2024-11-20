using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IAddressTypesRepository
    {
        List<AddressType> GetList(SqlConnection conn, SqlTransaction? tran = null);
    }
}
