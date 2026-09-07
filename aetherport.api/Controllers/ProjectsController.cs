using aetherport.api.DTO.Projects;
using aetherport.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aetherport.api.Data;

namespace aetherport.api.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public sealed class ProjectsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ResponseProject>>> GetAllProjects(
        CancellationToken cancellationToken)
    {
        var projects = await dbContext.Projects
            .AsNoTracking()
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => ToResponse(p))
            .ToListAsync(cancellationToken);
        return Ok(projects);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ResponseProject>> GetProjectById(
        int id,
        CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(
                p => p.Id == id,
                cancellationToken
            );

            if (project is null)
            {
                return NotFound();
            }

            return Ok(ToResponse(project));
    }

    [HttpPost]
    public async Task<ActionResult<ResponseProject>> CreateProject(
        CreateProjectRequest request,
        CancellationToken cancellationToken)
    {
        // check slug is unique
        // trim and convert to lowercase for consistency
        var slug = request.Slug.Trim().ToLowerInvariant();
        // check if slug already exists in the database
        var slugExists = await dbContext.Projects.AnyAsync(
            p => p.Slug == slug,
            cancellationToken
        );
        // error if so
        if (slugExists)
        {
            return Conflict(new { message = "Slug already exists with that name." });
        }  
        // create new project
        var project = new Project
        {
            Title = request.Title.Trim(),
            Slug = slug,
            Description = request.Description.Trim(),
            Completed = request.Completed
        };
        // save to database
        dbContext.Projects.Add(project);
        await dbContext.SaveChangesAsync(cancellationToken);
        // return the created project
        var response = ToResponse(project);
        return CreatedAtAction(
            nameof(GetProjectById),
            new { id = project.Id },
            response
        );
    }
        // helper method to convert Project to ResponseProject
        private static ResponseProject ToResponse(Project project) 
        {
            return new ResponseProject(
                project.Id,
                project.Title,
                project.Slug,
                project.Description,
                project.Completed,
                project.CreatedAt,
                project.UpdatedAt
            );
        }
}

    

