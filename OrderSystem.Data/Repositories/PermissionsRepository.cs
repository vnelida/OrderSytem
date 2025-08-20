using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class PermissionsRepository : IPermissionRepository
    {
        public void AddPermissionToRol(int roleId, int permissionId, SqlConnection conn, SqlTransaction tran)
        {
            var sql = @"INSERT INTO PermissionsRoles (RoleId, PermissionId)
                        VALUES (@RoleId, @PermissionId);";

            conn.Execute(sql, new { RoleId = roleId, PermissionId = permissionId }, transaction: tran);
        }

        public List<Permission>? GetListAssigned(int roleId, SqlConnection conn)
        {
            List<Permission> list = new List<Permission>();
            try
            {
                var selectQuery = @"SELECT
                                        p.PermissionId,
                                        p.Menu
                                    FROM Roles AS r
                                    INNER JOIN PermissionsRoles AS pr ON r.RoleId = pr.RoleId
                                    INNER JOIN Permissions AS p ON pr.PermissionId = p.PermissionId
                                    WHERE r.RoleId = @RoleId";
                return conn.Query<Permission>(selectQuery, new { RoleId = roleId }).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Permission>? GetListUnassigned(int roleId, SqlConnection conn)
        {
            var selectQuery = @"SELECT
                            p.PermissionId,
                            p.Menu
                        FROM Permissions AS p
                        LEFT JOIN PermissionsRoles AS pr ON p.PermissionId = pr.PermissionId AND pr.RoleId = @RoleId
                        WHERE pr.RoleId IS NULL;";

            return conn.Query<Permission>(selectQuery, new { RoleId = roleId }).ToList();
        }

        public List<Permission>? GetPermisos(int permissionId, SqlConnection conn)
        {
            List<Permission> list = new List<Permission>();
            try
            {
                var selectQuery = @"SELECT PermissionId, Menu 
                        FROM Permissions WHERE PermissionId=@PermissionId";
                return conn.Query<Permission>(selectQuery, new { @id = permissionId }).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void RemovePermissionFromRol(int roleId, int permissionId, SqlConnection conn, SqlTransaction tran)
        {
            var sql = @"DELETE FROM PermissionsRoles
                        WHERE RoleId = @RoleId AND PermissionId = @PermissionId;";

            conn.Execute(sql, new { RoleId = roleId, PermissionId = permissionId }, transaction: tran);

        }
    }
}
