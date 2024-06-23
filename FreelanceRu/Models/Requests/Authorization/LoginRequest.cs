using FreelanceRu.Models.Responses;

namespace FreelanceRu.Models.Requests.Authorization;

public record LoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
