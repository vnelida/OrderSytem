namespace Entities.Entities
{
    public class PermissionRol
    {
        public int PermissionRolId { get; set; }
        public int RolId { get; set; }
        public int PermissionId { get; set; }
        public Rol? Rol { get; set; }
        public Permission? Permission { get; set; }
    }
}
