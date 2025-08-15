namespace Entities.Entities
{
    public class Rol
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string? Description { get; set; }
        public List<PermissionRol> Permissions { get; set; }

        public Rol()
        {
            Permissions = new List<PermissionRol>();
        }
    }
}
