using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record Pacs008EmbeddedContentDto
{
    [Required]
    required public string MessaggioPacs008 { get; init; }
}