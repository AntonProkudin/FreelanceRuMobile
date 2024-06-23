using System.Text.Json.Serialization;

namespace FreelanceRu.Models.Responses.Task;

public record SaveTaskResponse : BaseResponse
{
    public  Models.Task? Task { get; set; }
}
public record GetTasksResponse : BaseResponse
{
    public List<Models.Task>? Tasks { get; set; }
}
public record DeleteTaskResponse : BaseResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int TaskId { get; set; }
}
public record TaskResponse
{
    public required int UserId { get; set; }
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required decimal Price { get; set; }
    public required bool IsCompleted { get; set; }
    public required DateTime Ts { get; set; }
}