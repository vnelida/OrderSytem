using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class RolesRepository : IRolRepository
    {
        public Rol? GetRolPorId(int rolId, SqlConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}
