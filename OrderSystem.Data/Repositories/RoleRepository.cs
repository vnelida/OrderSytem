using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public List<Rol> GetAllRoles(SqlConnection connection, SqlTransaction? tran = null)
        {
            var sql = "SELECT RoleId, RoleName FROM Roles";
            return connection.Query<Rol>(sql, transaction: tran).ToList();
        }

        public List<Permission> GetAllPermissions(SqlConnection connection, SqlTransaction? tran = null)
        {
            var sql = "SELECT PermissionId, Menu FROM Permissions";
            return connection.Query<Permission>(sql, transaction: tran).ToList();
        }

        public List<Permission> GetPermissionsByRoleId(SqlConnection connection, int roleId, SqlTransaction? tran = null)
        {
            var sql = @"
            SELECT p.PermissionId, p.Menu
            FROM Permissions p
            INNER JOIN PermissionsRoles pr ON p.PermissionId = pr.PermissionId
            WHERE pr.RoleId = @RoleId";
            return connection.Query<Permission>(sql, new { RoleId = roleId }, transaction: tran).ToList();
        }

        public void AddPermissionToRole(SqlConnection connection, int roleId, int permissionId, SqlTransaction tran)
        {
            var sql = "INSERT INTO PermissionsRoles (RoleId, PermissionId) VALUES (@RoleId, @PermissionId)";
            connection.Execute(sql, new { RoleId = roleId, PermissionId = permissionId }, transaction: tran);
        }
        public void RemovePermissionFromRole(SqlConnection connection, int roleId, int permissionId, SqlTransaction tran)
        {
            var sql = "DELETE FROM PermissionsRoles WHERE RoleId = @RoleId AND PermissionId = @PermissionId";
            connection.Execute(sql, new { RoleId = roleId, PermissionId = permissionId }, transaction: tran);
        }
    }
}
