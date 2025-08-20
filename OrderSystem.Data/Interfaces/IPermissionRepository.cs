using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IPermissionRepository
    {
        void AddPermissionToRol(int roleId, int permissionId, SqlConnection conn, SqlTransaction tran);
        List<Permission>? GetListAssigned(int roleId, SqlConnection conn);
        List<Permission>? GetListUnassigned(int roleId, SqlConnection conn);
        List<Permission>? GetPermisos(int permissionId, SqlConnection conn);
        void RemovePermissionFromRol(int roleId, int permissionId, SqlConnection conn, SqlTransaction tran);
    }
}
