using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record Pacs002EmbeddedContentDto
{
    [Required]
    required public string MessaggioPacs002 { get; init; }
}