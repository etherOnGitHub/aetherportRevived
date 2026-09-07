namespace aetherport.api.DTO.Projects;

public sealed record ResponseProject(
    int Id,
    string Title,
    string Slug,
    string Description,
    bool Completed,
    DateTime CreatedAt,
    DateTime UpdatedAt
);