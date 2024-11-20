using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IPhoneTypesRepository
    {
        List<PhoneType> GetList(SqlConnection conn, SqlTransaction? tran = null);
    }
}
