using System.ComponentModel.DataAnnotations;

namespace InstaPay.Api.Controllers.Dtos;

public record Pacs002DataDto : IDataDto
{
    [Required]
    [StringLength(3)]
    required public string Direction { get; init; }

    [Required]
    [StringLength(35)]
    required public string MsgId { get; init; }

    [Required]
    [StringLength(35)]
    required public string OrgnlMsgId { get; init; }

    [Required]
    [StringLength(35)]
    required public string TransactionId { get; init; }

    [Required]
    [StringLength(35)]
    required public string OrgnlMsgNmId { get; init; }

    public string? IntrBkSttlmDt { get; init; } // YYYY-MM-DD

    [Required]
    [StringLength(8)]
    required public string LclInstrm { get; init; } // INST - INSTTC01 - INSTNT01

    [Required]
    [StringLength(70)]
    required public string StsId { get; init; }

    [StringLength(5)]
    public string? StsRsnInf { get; init; }

    [StringLength(4)]
    required public string GrpSts { get; init; }

    [StringLength(10)]
    public string? ReasonCd { get; init; }

    [StringLength(35)]
    public string? OrgnlInstrId { get; init; }

    [StringLength(35)]
    required public string OrgnlEndToEndId { get; init; }

    [StringLength(35)]
    required public string OrgnlTxId { get; init; }

    [Required]
    required public string OrgnlAccptncDtTm { get; init; }

    [StringLength(35)]
    required public string OrgnlTxRefBIC { get; init; }

    public decimal? OrgnIntrBkSttlmAmt { get; init; }

    required public Pacs002EmbeddedContentDto Pacs002 { get; init; }
}
