namespace InstaPay.Api.Domain.Models;

public record PaymentDetails
{
    required public decimal Amount { get; init; }
    required public string Currency { get; init; }
    public string? CtgyPurpCode { get; init; }
    public string? CtgyPurpValue { get; init; }
    required public string Uri { get; init; }
    public string? RemittanceInfoStrd { get; init; }
    public string? RemittanceInfoStrd_CdtrRefInfCd { get; init; }
    public string? RemittanceInfoStrd_CdtrRefInfIssr { get; init; }
    public string? RemittanceInfoStrd_CdtrRefInfRef { get; init; }
}