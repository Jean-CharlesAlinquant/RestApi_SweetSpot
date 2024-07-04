namespace InstaPay.Api.Domain.Models;

public record BeneficiaryField
{
    required public string BeneficiaryName { get; init; }
    public string? BeneficiaryLEI { get; init; }
    public string? BeneficiaryAccountProxy { get; init; }
    required public string BeneficiaryIban { get; init; }
    required public string BeneficiaryBic { get; init; }
    public PostalAddress? PostalAddress { get; init; }
    public string? BeneficiaryAddress { get; init; }
    public string? BeneficiaryCountry { get; init; }
    public string? BeneficiaryBankName { get; init; }
    public string? BeneficiaryPrvId { get; init; }
    public string? BeneficiaryUltimateName { get; init; }
    public string? BeneficiaryUltimateLEI { get; init; }
    public string? BeneficiaryUltimateId { get; init; }
}