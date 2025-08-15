using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IRolRepository
    {
        Rol? GetRolPorId(int rolId, SqlConnection conn);
    }
}
