using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InstaPay.Api.Domain.Models;

public class SepaMessage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    required public string TransactionId { get; set; }
    required public SepaHeader Header { get; set; }
    required public Sepa008Data Data { get; set; }
    public DateTime CreateTimestamp { get; set; }
}