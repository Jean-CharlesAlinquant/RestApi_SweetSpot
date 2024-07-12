using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record Pacs008DataDto : IDataDto
{
    [Required]
    [StringLength(8)]
    required public string LclInstrm { get; init; } // INST - INSTTC01 - INSTNT01

    [Required]
    [StringLength(35)]
    required public string TransactionId { get; init; }

    [Required]
    required public string SttlmntDate { get; init; } // "YYYY-MM-DD

    [Required]
    required public string SCTInstTimestamp { get; init; }

    required public OrderDto OrderField { get; init; }

    required public BeneficiaryDto BeneficiaryField { get; init; }

    required public PaymentDetailsDto PaymentDetails { get; init; }

    required public Pacs008EmbeddedContentDto Pacs008 { get; init; }
}
