using Entities.Entities;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        List<Rol> GetAllRoles();
        List<Permission> GetAllPermissions();
        List<Permission> GetPermissionsByRoleId(int roleId);
        void AddPermissionToRole(int roleId, int permissionId);
        void RemovePermissionFromRole(int roleId, int permissionId);        
    }
}
