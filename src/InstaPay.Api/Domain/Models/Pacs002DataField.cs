namespace InstaPay.Api.Domain.Models;

public record Pacs002DataField : IDataField
{
    required public string Direction { get; init; }
    required public string MsgId { get; init; }
    required public string OrgnlMsgId { get; init; }
    required public string TransactionId { get; init; }
    required public string OrgnlMsgNmId { get; init; }
    public string? IntrBkSttlmDt { get; init; }
    required public string LclInstrm { get; init; }
    required public string StsId { get; init; }
    public string? StsRsnInf { get; init; }
    required public string GrpSts { get; init; }
    public string? ReasonCd { get; init; }
    public string? OrgnlInstrId { get; init; }
    required public string OrgnlEndtoEndId { get; init; }
    required public string OrgnlTxId { get; init; }
    required public string OrgnlAccptncDtTm { get; init; }
    required public string OrgnlTxRefBIC { get; init; }
    public string? OrgnIntrBkSttlmAmt { get; init; }
    required public Pacs002 Pacs002 { get; init; }
}