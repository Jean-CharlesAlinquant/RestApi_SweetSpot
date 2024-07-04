namespace InstaPay.Api.Domain.Models;

public record CreditResponse
{
    required public string CreationTimestamp { get; init; }
    public string? CorrelationKey { get; init; }
    public string FormatType { get; init; } = "JSN";
    public string? OperationCode { get; init; }
    required public string MessageType { get; init; }
    public string ResponseTimestamp { get; init; } = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
    public string? ACH { get; init; }
    public string? TransactionId { get; init; }
    required public string ReturnCode { get; init; }
    public string? ReturnDescription { get; init; }
    required public string PaymentStatus { get; init; }

    // For testing
    public IDataField? Data { get; init; }
}