namespace InstaPay.Api.Infrastructure.Settings;

public class MongoDbSettings
{
    required public string Host { get; init; }
    public int Port { get; init; }
    public string ConnectionString => $"mongodb://{Host}:{Port}";
    required public string DatabaseName { get; init; }
    required public string CollectionName { get; init; }
}