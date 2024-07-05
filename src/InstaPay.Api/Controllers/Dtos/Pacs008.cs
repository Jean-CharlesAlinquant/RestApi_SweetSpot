using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record Pacs008
{
    [Required]
    required public string MessaggioPacs008 { get; init; }
}