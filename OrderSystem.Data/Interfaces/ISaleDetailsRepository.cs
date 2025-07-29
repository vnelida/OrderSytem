using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface ISaleDetailsRepository
    {
        void Add(SaleDetail details, SqlConnection conn, SqlTransaction tran);

    }
}
