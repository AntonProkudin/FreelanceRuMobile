namespace FreelanceRu.Models.Requests.Authorization;

public record RefreshTokenRequest
{
    public required int UserId { get; set; }
    public required string RefreshToken { get; set; }
}
