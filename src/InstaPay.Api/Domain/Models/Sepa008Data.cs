namespace InstaPay.Api.Domain.Models;

public class Sepa008Data
{
    required public string LclInstrm { get; init; }
    required public string TransactionId { get; init; }
    required public string SttlmntDate { get; init; }
    required public string SCTInstTimestamp { get; init; }
    required public SepaOrder Order { get; init; }
    required public SepaBeneficiary Beneficiary { get; init; }
    required public SepaPaymentDetails PaymentDetails { get; init; }
    required public SepaPacs008 Pacs008 { get; init; }

    public override string ToString()
    {
        return $"Sepa008Data:\n" +
               $"  LclInstrm: {LclInstrm}\n" +
               $"  TransactionId: {TransactionId}\n" +
               $"  SttlmntDate: {SttlmntDate}\n" +
               $"  SCTInstTimestamp: {SCTInstTimestamp}\n" +
               $"  Order:\n{Order}\n" +
               $"  Beneficiary:\n{Beneficiary}\n" +
               $"  PaymentDetails:\n{PaymentDetails}\n" +
               $"  Pacs008:\n{Pacs008}";
    }
}