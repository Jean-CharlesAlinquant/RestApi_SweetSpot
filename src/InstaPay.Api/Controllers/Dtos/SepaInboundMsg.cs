using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record SepaInboundMsg
{
    [Required]
    [StringLength(3)]
    required public string Version { get; init; }

    [Required]
    [StringLength(10)]
    required public string ApplicationId { get; init; }

    [Required]
    [StringLength(1)]
    required public string LocalAddressType { get; init; }

    [Required]
    [StringLength(100)]
    required public string LocalAddress { get; init; }

    [StringLength(1)]
    public string? RemoteAddressType { get; init; }

    [StringLength(100)]
    public string? RemoteAddress { get; init; }

    [Required]
    [StringLength(4)]
    required public string ACH { get; init; }

    [StringLength(4)]
    public string? SettlementMethod { get; init; }

    [Required]
    [StringLength(100)]
    required public string Service { get; init; }

    [Required]
    [StringLength(3)]
    required public string FormatType { get; init; }

    [Required]
    [StringLength(20)]
    required public string OperationCode { get; init; }

    [Required]
    [StringLength(40)]
    required public string MessageType { get; init; }

    [Required]
    required public DateTime CreationTimestamp { get; init; }

    [StringLength(100)]
    public string? CorrelationKey { get; init; }

    [StringLength(150)]
    public string? Signature { get; init; }

    required public string ReturnCode { get; init; }

    [Required]
    required public IDataField Data { get; init; }
}