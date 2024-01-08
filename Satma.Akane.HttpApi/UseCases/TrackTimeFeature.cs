using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace Satma.Akane.HttpApi.UseCases;

public sealed class SpentTimeDto
{
    [Required, MinLength(5)]
    public required string TeamMemberName { get; init; }
    
    [Required, MinLength(3)]
    public required string ProjectTitle { get; init; }
    
    [Required, MinLength(2)]
    public required string ActivityDescription { get; init; }
    
    [Required, Range(1, 24 * 60)]
    public required int MinutesSpent { get; init; }
    
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
