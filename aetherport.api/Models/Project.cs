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
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}