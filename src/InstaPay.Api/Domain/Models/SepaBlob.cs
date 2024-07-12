namespace InstaPay.Api.Domain.Models;

public class SepaBlob
{
    required public string TransactionId { get; set; }
    required public string Content { get; set; }
    public DateTime CreatedTimestamp { get; set; }

    public override string ToString()
    {
        return $"SepaMessage:\n" +
               $"  TransactionId: {TransactionId}\n" +
               $"  Content:\n{Content}\n" +
               $"  CreatedTimestamp: {CreatedTimestamp}";
    }
}