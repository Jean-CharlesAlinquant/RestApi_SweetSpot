using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record OrderField
{
    [Required]
    [StringLength(7)]
    required public string OriginatorName { get; init; }

    [StringLength(20)]
    public string? OriginatorLEI { get; init; }

    public string? OriginatorAccountProxy { get; init; }

    [Required]
    [StringLength(35)]
    required public string OriginatorIban { get; init; }

    [StringLength(35)]
    public string? OriginatorCountry { get; init; }

    public PostalAddress? OriginatorPostalAddress { get; init; }

    [StringLength(40)]
    public string? OriginatorAddress { get; init; }

    [StringLength(100)]
    public string? OriginatorPrvId { get; init; }

    [StringLength(70)]
    public string? OriginatorUltimateName { get; init; }

    [StringLength(20)]
    public string? OriginatorUltimateLEI { get; init; }

    [StringLength(100)]
    public string? OriginatorUltimateId { get; init; }
}