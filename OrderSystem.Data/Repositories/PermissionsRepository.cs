using Dapper;
using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PermissionsRepository : IPermissionRepository
    {
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
    }
}
