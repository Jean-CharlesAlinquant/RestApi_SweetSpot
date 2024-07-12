using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record PaymentDetailsDto
{
    [Required]
    required public decimal Amount { get; init; }

    [Required]
    [StringLength(3)]
    required public string Currency { get; init; }

    [StringLength(4)]
    public string? CtgyPurpCode { get; init; }

    [StringLength(35)]
    public string? CtgyPurpValue { get; init; }

    [Required]
    [StringLength(35)]
    required public string Uri { get; init; }

    [StringLength(40)]
    public string? RemittanceInfo { get; init; }

    [StringLength(4)]
    public string? RemittanceInfoStrd_CdtrRefInfCd { get; init; }

    [StringLength(35)]
    public string? RemittanceInfoStrd_CdtrRefInfIssr { get; init; }

    [StringLength(35)]
    public string? RemittanceInfoStrd_CdtrRefInfRef { get; init; }
}