using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly string _connectionString;

        public RoleService(IRoleRepository roleRepository, string connectionString)
        {
            _repository = roleRepository ?? throw new ApplicationException("Dependencies not loaded."); ;
            _connectionString = connectionString;
        }
        public List<Rol> GetAllRoles()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return _repository.GetAllRoles(connection);
            }
        }

        public List<Permission> GetAllPermissions()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return _repository.GetAllPermissions(connection);
            }
        }

        public List<Permission> GetPermissionsByRoleId(int roleId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return _repository.GetPermissionsByRoleId(connection, roleId);
            }
        }

        public void AddPermissionToRole(int roleId, int permissionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        _repository.AddPermissionToRole(connection, roleId, permissionId, tran);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void RemovePermissionFromRole(int roleId, int permissionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        _repository.RemovePermissionFromRole(connection, roleId, permissionId, tran);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
