namespace FreelanceRu.Models.Responses.Authorization;

public record TokenResponse : BaseResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }

}