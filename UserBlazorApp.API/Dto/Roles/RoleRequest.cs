using UserBlazorApp.API.Dto.Claims;

namespace UserBlazorApp.API.Dto.Roles
{
    public class RoleRequest
    {
        public string? Name { get; set; }

        public ICollection<RoleClaimsRequest> RoleClaimReq { get; set; } = new List<RoleClaimsRequest>();



    }
}
