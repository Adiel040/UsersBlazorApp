﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UserBlazorApp.API.Dto.Roles;

namespace UserBlazorApp.UI.Dto.User
{
    public class UserResponse
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public ICollection<RoleResponse> Role { get; set; } = new List<RoleResponse>();
    }
}
