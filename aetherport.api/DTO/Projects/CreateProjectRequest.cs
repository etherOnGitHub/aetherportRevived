using System.ComponentModel.DataAnnotations;

namespace aetherport.api.DTO.Projects;

public sealed record CreateProjectRequest
{
    [Required, MaxLength(100)]
    public required string Title;
    [Required, MaxLength(50)]
    public required string Slug; 
    [Required, MaxLength(200)]
    public required string Description;

    public bool Completed;
}