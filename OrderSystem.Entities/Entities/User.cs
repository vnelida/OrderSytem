namespace Entities.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
        public Rol Rol { get; set; }

    }
}
