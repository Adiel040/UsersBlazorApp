namespace UserBlazorApp.API.Dto.Claims
{
    public class RoleClaimsRequest
    {
        public int RoleId { get; set; }
        public string? Claimtype { get; set; }
        public string? Claimvalue { get; set; }
    }
}
