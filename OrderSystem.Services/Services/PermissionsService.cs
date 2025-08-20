using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class PermissionsService : IPermissionService
    {
        private readonly IPermissionRepository? _repository;
        private readonly string? _cadena;
        public PermissionsService(IPermissionRepository? repository, string? cadena)
        {
            _repository = repository ?? throw new ApplicationException("Dependencies not loaded."); ;
            _cadena = cadena;
        }

        public void AddPermissionToRol(int roleId, int permissionId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    _repository.AddPermissionToRol(roleId, permissionId, conn, tran);
                    tran.Commit();
                }
            }
        }

        public List<Permission>? GetList()
        {
            throw new NotImplementedException();
        }

        public List<Permission>? GetListAssigned(int roleId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetListAssigned(roleId, conn);
            }
        }

        public List<Permission>? GetListUnassigned(int roleId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetListUnassigned(roleId, conn);
            }
        }

        public void RemovePermissionFromRol(int roleId, int permissionId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    _repository.RemovePermissionFromRol(roleId, permissionId, conn, tran);
                    tran.Commit();
                }
            }
        }
    }
}
