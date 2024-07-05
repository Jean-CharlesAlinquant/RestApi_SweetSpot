using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record Pacs002
{
    [Required]
    required public string MessaggioPacs002 { get; init; }
}