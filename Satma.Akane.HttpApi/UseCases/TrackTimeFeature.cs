using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace Satma.Akane.HttpApi.UseCases;

public sealed class SpentTimeDto
{
    /// <example>Trevor Smith</example>
    [Required, Length(5, 35)]
    public required string TeamMemberName { get; init; }
    
    /// <example>Akane</example>
    [Required, Length(3, 20)]
    public required string ProjectTitle { get; init; }
    
    /// <example>QA</example>
    [Required, Length(2, 15)]
    public required string ActivityDescription { get; init; }
    
    /// <example>120</example>
    [Required, Range(1, 24 * 60)]
    public required int MinutesSpent { get; init; }
    
    /// <example>2024-01-15</example>
    [Required]
    public required DateOnly Date { get; init; }
}

[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public sealed class TrackTimeFeature : ControllerBase
{
    [HttpPost("/track-time")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult TrackTime([FromBody] SpentTimeDto _) =>
        Ok();
}
