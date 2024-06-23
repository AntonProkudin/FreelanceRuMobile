namespace FreelanceRu.Models;

public record News
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Url { get; set; }
    public required DateTime Ts { get; set; }
}
