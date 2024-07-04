namespace InstaPay.Api.Domain.Models;

public record OrderField
{
    required public string OriginatorName { get; init; }
    public string? OriginatorLEI { get; init; }
    public string? OriginatorAccountProxy { get; init; }
    required public string OriginatorIban { get; init; }
    public string? OriginatorCountry { get; init; }
    public PostalAddress? PostalAddress { get; init; }
    public string? OriginatorAddress { get; init; }
    public string? OriginatorPrvId { get; init; }
    public string? OriginatorUltimateName { get; init; }
    public string? OriginatorUltimateLEI { get; init; }
    public string? OriginatorUltimateId { get; init; }
}