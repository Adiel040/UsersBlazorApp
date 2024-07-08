namespace UserBlazorApp.API.Dto.Claims
{
    public class RoleClaimsResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Claimtype { get; set; }
        public string? Claimvalue { get; set; }
    }
}
