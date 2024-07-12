namespace InstaPay.Api.Domain.Models;

public class SepaBeneficiary
{
    required public string BeneficiaryName { get; init; }
    public string? BeneficiaryLEI { get; init; }
    public string? BeneficiaryAccountProxy { get; init; }
    required public string BeneficiaryIban { get; init; }
    required public string BeneficiaryBic { get; init; }
    public SepaAddress? PostalAddress { get; init; }
    public string? BeneficiaryAddress { get; init; }
    public string? BeneficiaryCountry { get; init; }
    public string? BeneficiaryBankName { get; init; }
    public string? BeneficiaryPrvId { get; init; }
    public string? BeneficiaryUltimateName { get; init; }
    public string? BeneficiaryUltimateLEI { get; init; }
    public string? BeneficiaryUltimateId { get; init; }

    public override string ToString()
    {
        return $"SepaBeneficiary:\n" +
               $"  BeneficiaryName: {BeneficiaryName}\n" +
               $"  BeneficiaryLEI: {BeneficiaryLEI ?? "N/A"}\n" +
               $"  BeneficiaryAccountProxy: {BeneficiaryAccountProxy ?? "N/A"}\n" +
               $"  BeneficiaryIban: {BeneficiaryIban}\n" +
               $"  BeneficiaryBic: {BeneficiaryBic}\n" +
               $"  PostalAddress: {(PostalAddress != null ? PostalAddress.ToString() : "N/A")}\n" +
               $"  BeneficiaryAddress: {BeneficiaryAddress ?? "N/A"}\n" +
               $"  BeneficiaryCountry: {BeneficiaryCountry ?? "N/A"}\n" +
               $"  BeneficiaryBankName: {BeneficiaryBankName ?? "N/A"}\n" +
               $"  BeneficiaryPrvId: {BeneficiaryPrvId ?? "N/A"}\n" +
               $"  BeneficiaryUltimateName: {BeneficiaryUltimateName ?? "N/A"}\n" +
               $"  BeneficiaryUltimateLEI: {BeneficiaryUltimateLEI ?? "N/A"}\n" +
               $"  BeneficiaryUltimateId: {BeneficiaryUltimateId ?? "N/A"}";
    }
}