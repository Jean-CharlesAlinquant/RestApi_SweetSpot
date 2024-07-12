namespace InstaPay.Api.Domain.Models;

public class SepaPaymentDetails
{
    required public decimal Amount { get; init; }
    required public string Currency { get; init; }
    public string? CtgyPurpCode { get; init; }
    public string? CtgyPurpValue { get; init; }
    required public string Uri { get; init; }
    public string? RemittanceInfo { get; init; }
    public string? RemittanceInfoStrd_CdtrRefInfCd { get; init; }
    public string? RemittanceInfoStrd_CdtrRefInfIssr { get; init; }
    public string? RemittanceInfoStrd_CdtrRefInfRef { get; init; }
    public override string ToString()
    {
        return $"SepaPaymentDetails:\n" +
               $"  Amount: {Amount}\n" +
               $"  Currency: {Currency}\n" +
               $"  CtgyPurpCode: {CtgyPurpCode ?? "N/A"}\n" +
               $"  CtgyPurpValue: {CtgyPurpValue ?? "N/A"}\n" +
               $"  Uri: {Uri}\n" +
               $"  RemittanceInfo: {RemittanceInfo ?? "N/A"}\n" +
               $"  RemittanceInfoStrd_CdtrRefInfCd: {RemittanceInfoStrd_CdtrRefInfCd ?? "N/A"}\n" +
               $"  RemittanceInfoStrd_CdtrRefInfIssr: {RemittanceInfoStrd_CdtrRefInfIssr ?? "N/A"}\n" +
               $"  RemittanceInfoStrd_CdtrRefInfRef: {RemittanceInfoStrd_CdtrRefInfRef ?? "N/A"}";
    }
}