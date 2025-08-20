using Entities.Entities;

namespace Services.Interfaces
{
    public interface IPermissionService
    {
        void AddPermissionToRol(int roleId, int permissionId);
        List<Permission>? GetList();
        List<Permission>? GetListAssigned(int roleId);
        List<Permission>? GetListUnassigned(int roleId);
        void RemovePermissionFromRol(int roleId, int permissionId);
    }
}
