using System.ComponentModel.DataAnnotations;

namespace FreelanceRu.Models.Requests.Authorization;

public record SignupRequest
{
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateTime Ts { get; set; }
}
