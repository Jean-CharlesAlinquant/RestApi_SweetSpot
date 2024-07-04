namespace InstaPay.Api.Domain.Models;

public record Pacs008DataField : IDataField
{
    required public string LclInstrm { get; init; }
    required public string TransactionId { get; init; }
    required public string SttlmntDate { get; init; }
    required public string SCTInstTimestamp { get; init; }
    required public OrderField OrderField { get; init; }
    required public BeneficiaryField BeneficiaryField { get; init; }
    required public PaymentDetails PaymentDetails { get; init; }
    required public Pacs008 Pacs008 { get; init; }
}