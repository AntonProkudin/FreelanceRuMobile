namespace FreelanceRu.Models;

public record UserAvatar
{
    public required int UserId { get; set; }
    public required string Path { get; set; } = "image/default.png";
}
