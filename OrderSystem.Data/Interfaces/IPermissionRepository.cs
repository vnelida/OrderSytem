using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IPermissionRepository
    {
        List<Permission>? GetPermisos(int permissionId, SqlConnection conn);
    }
}
