namespace FreelanceRu.Models.Responses.Authorization;

public record ValidateRefreshTokenResponse : BaseResponse
{
    public int UserId { get; set; }
}
