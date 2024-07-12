namespace InstaPay.Api.Domain.Models;

public class SepaOrder
{
    required public string OriginatorName { get; init; }
    public string? OriginatorLEI { get; init; }
    public string? OriginatorAccountProxy { get; init; }
    required public string OriginatorIban { get; init; }
    public string? OriginatorCountry { get; init; }
    public SepaAddress? PostalAddress { get; init; }
    public string? OriginatorAddress { get; init; }
    public string? OriginatorPrvId { get; init; }
    public string? OriginatorUltimateName { get; init; }
    public string? OriginatorUltimateLEI { get; init; }
    public string? OriginatorUltimateId { get; init; }

    public override string ToString()
    {
        return $"SepaOrder:\n" +
               $"  OriginatorName: {OriginatorName}\n" +
               $"  OriginatorLEI: {OriginatorLEI ?? "N/A"}\n" +
               $"  OriginatorAccountProxy: {OriginatorAccountProxy ?? "N/A"}\n" +
               $"  OriginatorIban: {OriginatorIban}\n" +
               $"  OriginatorCountry: {OriginatorCountry ?? "N/A"}\n" +
               $"  Address: {(PostalAddress != null ? PostalAddress.ToString() : "N/A")}\n" +
               $"  OriginatorAddress: {OriginatorAddress ?? "N/A"}\n" +
               $"  OriginatorPrvId: {OriginatorPrvId ?? "N/A"}\n" +
               $"  OriginatorUltimateName: {OriginatorUltimateName ?? "N/A"}\n" +
               $"  OriginatorUltimateLEI: {OriginatorUltimateLEI ?? "N/A"}\n" +
               $"  OriginatorUltimateId: {OriginatorUltimateId ?? "N/A"}";
    }
}