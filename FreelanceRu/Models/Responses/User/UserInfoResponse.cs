namespace FreelanceRu.Models.Responses.User;

public class UserInfoResponse
{
    public int Id { get; set; }
    public  string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Avatar { get; set; }
    public DateTime Ts { get; set; }
    public bool Active { get; set; }
    public virtual ICollection<SkillsResponse> UserSkills { get; set; }
}
