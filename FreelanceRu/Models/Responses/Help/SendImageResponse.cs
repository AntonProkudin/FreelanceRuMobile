namespace FreelanceRu.Models.Responses.Help;

public record SendImageResponse
{
    public string Url { get; set; }
    public string Ex { get; set; } = null;
}
