using System.Text.Json.Serialization;

namespace FreelanceRu.Models.Responses.News;
public record GetNewsResponse : BaseResponse
{
    public List<Models.News>? News { get; set; }
}
public record GetNewResponse : BaseResponse
{
    public Models.News? News { get; set; }
}
public record NewsResponse
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Url { get; set; }
    public required DateTime Ts { get; set; }
}
public record NewsResponseFormated
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Url { get; set; }
    public required DateTime Ts { get; set; }
    public bool Visible { get; set; } = false;
}