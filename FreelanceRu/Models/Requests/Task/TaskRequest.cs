namespace FreelanceRu.Models.Requests.Task;
public record TaskRequest
{
    public required int CategoryId { get; set; }
    public required decimal Price { get; set; }
    public required string Description { get; set; }
    public required string Title { get; set; }
    public required bool IsCompleted { get; set; }
    public required DateTime Ts { get; set; }
}
public record CategoryRequest
{
    public required string Title { get; set; }
}