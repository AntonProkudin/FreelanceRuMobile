namespace FreelanceRu.Models;

public class Message
{
    public long Id { get; set; } = 0;
    public required int FromUserId { get; set; }
    public required int ToUserId { get; set; }
    public required string Text { get; set; }
    public required DateTime SendTime { get; set; }
    public bool IsRead { get; set; } = false;
    public string Type { get; set; } = "text";
}
