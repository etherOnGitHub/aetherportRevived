namespace aetherport.api.Models;

public class Project 
{
    public int Id { get; set; }
    public required string Title { get; set; } = null!;
    public required string Slug { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<Tag> Tags { get; set; } = new List<Tag>();
    public List<string> Images { get; set; } = new List<string>();
    public List<string> Links { get; set; } = new List<string>();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}