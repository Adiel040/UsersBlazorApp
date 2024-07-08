using UserBlazorApp.API.Dto.Claims;

namespace UserBlazorApp.API.Dto.Roles
{
    public class RoleResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<RoleClaimsResponse> RoleClaim { get; set; } = new List<RoleClaimsResponse>();


    }
}
