using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record Pacs008DataField : IDataField
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

    required public OrderField OrderField { get; init; }

    required public BeneficiaryField BeneficiaryField { get; init; }

    required public PaymentDetails PaymentDetails { get; init; }

    required public Pacs008 Pacs008 { get; init; }
}
