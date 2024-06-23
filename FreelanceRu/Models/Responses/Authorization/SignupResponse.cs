namespace FreelanceRu.Models.Responses.Authorization;

public record SignupResponse : BaseResponse
{
    public string? Email { get; set; }
}
