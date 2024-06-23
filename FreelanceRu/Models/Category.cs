namespace FreelanceRu.Models;

public partial record Category
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public virtual ICollection<Models.Task>? Tasks { get; set; }
}
