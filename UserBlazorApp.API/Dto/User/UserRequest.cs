using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserBlazorApp.API.Dto.User
{
    public class UserRequest
    {
       

        [StringLength(256)]
        public string? UserName { get; set; }

        [StringLength(256)]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        
    }
}
