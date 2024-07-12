using InstaPay.Api.Domain.Interfaces;
using InstaPay.Api.Domain.Models;
using MongoDB.Driver;

namespace InstaPay.Api.Infrastructure.Data;

public class MongoDbRepository : IRepository<SepaMessage>
{
    private readonly IMongoCollection<SepaMessage> _dbCollection;
    private readonly FilterDefinitionBuilder<SepaMessage> filterBuilder = Builders<SepaMessage>.Filter;

    public MongoDbRepository(IMongoDatabase database, string collectionName)
    {
        _dbCollection = database.GetCollection<SepaMessage>(collectionName);
    }

    public async Task<SepaMessage?> GetByIdAsync(string transactionId)
    {
        FilterDefinition<SepaMessage> filter = filterBuilder.Eq(entity => entity.TransactionId, transactionId);
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task SaveAsync(SepaMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        await _dbCollection.InsertOneAsync(message);
    }
}