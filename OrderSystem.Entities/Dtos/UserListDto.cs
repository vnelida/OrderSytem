﻿namespace Entities.Dtos
{
    public class UserListDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!; 
        public bool IsActive { get; set; }
    }
}
