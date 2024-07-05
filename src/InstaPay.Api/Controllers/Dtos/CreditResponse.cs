using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record CreditResponse // CreditRequest - Response
{
    [Required]
    required public string CreationTimestamp { get; init; }

    [StringLength(100)]
    public string? CorrelationKey { get; init; }

    [StringLength(3)]
    public string? FormatType { get; init; } = "JSN";

    [StringLength(20)]
    public string? OperationCode { get; init; }

    [Required]
    [StringLength(40)]
    required public string MessageType { get; init; } // PACS.008 - PACS.004

    [Required]
    public string ResponseTimestamp { get; init; } = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

    [StringLength(4)]
    public string? ACH { get; init; } // Optional field

    [StringLength(35)]
    public string? TransactionId { get; init; }

    [Required]
    [StringLength(8)]
    required public string ReturnCode { get; init; }

    [StringLength(100)]
    public string? ReturnDescription { get; init; } // REJECTED, ACCEPTED

    [Required]
    [StringLength(8)]
    required public string PaymentStatus { get; init; }

    // For testing
    public IDataField? Data { get; init; }
}