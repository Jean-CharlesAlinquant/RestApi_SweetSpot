namespace InstaPay.Api.Domain.Models;

public class SepaHeader
{
    required public string Version { get; init; }
    required public string ApplicationId { get; init; }
    required public string LocalAddressType { get; init; }
    required public string LocalAddress { get; init; }
    public string? RemoteAddressType { get; init; }
    public string? RemoteAddress { get; init; }
    public string? ACH { get; init; }
    public string? SettlementMethod { get; init; }
    required public string Service { get; init; }
    required public string FormatType { get; init; }
    required public string OperationCode { get; init; }
    required public string MessageType { get; init; }
    required public DateTime CreationTimestamp { get; init; }
    public string? CorrelationKey { get; init; }
    public string? Signature { get; init; }

    public override string ToString()
    {
                return $"SepaHeader:\n" +
               $"  Version: {Version}\n" +
               $"  ApplicationId: {ApplicationId}\n" +
               $"  LocalAddressType: {LocalAddressType}\n" +
               $"  LocalAddress: {LocalAddress}\n" +
               $"  RemoteAddressType: {RemoteAddressType ?? "N/A"}\n" +
               $"  RemoteAddress: {RemoteAddress ?? "N/A"}\n" +
               $"  ACH: {ACH ?? "N/A"}\n" +
               $"  SettlementMethod: {SettlementMethod ?? "N/A"}\n" +
               $"  Service: {Service}\n" +
               $"  FormatType: {FormatType}\n" +
               $"  OperationCode: {OperationCode}\n" +
               $"  MessageType: {MessageType}\n" +
               $"  CreationTimestamp: {CreationTimestamp:yyyy-MM-ddTHH:mm:ss.fffZ}\n" +
               $"  CorrelationKey: {CorrelationKey ?? "N/A"}\n" +
               $"  Signature: {Signature ?? "N/A"}";
    }
}