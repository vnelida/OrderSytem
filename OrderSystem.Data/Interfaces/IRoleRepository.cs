using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IRoleRepository
    {
        List<Rol> GetAllRoles(SqlConnection connection, SqlTransaction? tran = null);
        List<Permission> GetAllPermissions(SqlConnection connection, SqlTransaction? tran = null);
        List<Permission> GetPermissionsByRoleId(SqlConnection connection, int roleId, SqlTransaction? tran = null);
        void AddPermissionToRole(SqlConnection connection, int roleId, int permissionId, SqlTransaction tran);
        void RemovePermissionFromRole(SqlConnection connection, int roleId, int permissionId, SqlTransaction tran);

    }
}
