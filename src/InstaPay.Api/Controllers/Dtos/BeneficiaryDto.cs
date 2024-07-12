using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record BeneficiaryDto
{
    [Required]
    [StringLength(70)]
    required public string BeneficiaryName { get; init; }

    [StringLength(20)]
    public string? BeneficiaryLEI { get; init; }

    public string? BeneficiaryAccountProxy { get; init; }

    [Required]
    [StringLength(35)]
    required public string BeneficiaryIban { get; init; }

    [Required]
    [StringLength(50)]
    required public string BeneficiaryBic { get; init; }

    public PostalAddressDto? BeneficiaryPostalAddress { get; init; }

    [StringLength(140)]
    public string? BeneficiaryAddress { get; init; }

    [StringLength(70)]
    public string? BeneficiaryCountry { get; init; }

    [StringLength(50)]
    public string? BeneficiaryBankName { get; init; }

    [StringLength(100)]
    public string? BeneficiaryPrvId { get; init; }

    [StringLength(70)]
     public string? BeneficiaryUltimateName { get; init; }

    [StringLength(20)]
    public string? BeneficiaryUltimateLEI { get; init; }

    [StringLength(100)]
    public string? BeneficiaryUltimateId { get; init; }
}