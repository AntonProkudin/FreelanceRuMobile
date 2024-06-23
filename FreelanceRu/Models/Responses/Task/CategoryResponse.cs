using FreelanceRu.Models;
using System.Text.Json.Serialization;

namespace FreelanceRu.Models.Responses.Task;

public record SaveCategoryResponse : BaseResponse
{
    public Category? Category { get; set; }
}
public record GetCategoriesResponse : BaseResponse
{
    public List<Category>? Categories { get; set; }
}
public record DeleteCategoryResponse : BaseResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int CategoryId { get; set; }
}
public record CategoryResponse
{
    public required int Id { get; set; }
    public required string Title { get; set; }
}