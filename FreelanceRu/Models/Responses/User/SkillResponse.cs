using FreelanceRu.Models;
using System.Text.Json.Serialization;

namespace FreelanceRu.Models.Responses.User;

public record SaveSkillResponse : BaseResponse
{
    public UserSkill? Skill { get; set; }
}
public record GetSkillsResponse : BaseResponse
{
    public List<UserSkill>? Skills { get; set; }
}
public record DeleteSkillResponse : BaseResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int SkillId { get; set; }
}
public record SkillResponse
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required int UserId { get; set; }
}
public record SkillsResponse
{
    public required int Id { get; set; }
    public required string Title { get; set; }
}