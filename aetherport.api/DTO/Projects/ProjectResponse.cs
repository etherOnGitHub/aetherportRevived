namespace aetherport.api.DTO.Projects;

public sealed record ResponseProject(
    int Id,
    string Title,
    string Slug,
    string? Description,
    IReadOnlyList<string> Tags,
    IReadOnlyList<string> Images,
    IReadOnlyList<string> Links,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    bool Completed = false
);