namespace aetherport.api.Models;

public sealed class Project 
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Slug { get; set; }
    public required string Description { get; set; }
    public bool Completed { get; set; }
    public ICollection<Tag> Tags { get; set; } = [];
    public ICollection<string> Images { get; set; } = [];
    public ICollection<string> Links { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}