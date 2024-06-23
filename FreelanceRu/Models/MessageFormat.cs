namespace FreelanceRu.Models;

public class MessageFormat
{
    public required long Id { get; set; }
    public required int FromUserId { get; set; }
    public required int ToUserId { get; set; }
    public required string Text { get; set; }
    public required DateTime SendTime { get; set; }
    public bool IsRead { get; set; } = false;
    public string Type { get; set; } = "text";
    public Microsoft.Maui.Graphics.Color Color { get; set; } = Color.FromArgb("#00D65B");
    public Microsoft.Maui.Controls.LayoutOptions layoutOptions { get; set; } = LayoutOptions.Start;
}
