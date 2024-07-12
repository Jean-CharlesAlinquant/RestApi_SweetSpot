using InstaPay.Api.Domain.Interfaces;
using InstaPay.Api.Domain.Models;
using InstaPay.Api.Infrastructure.Converters;
using InstaPay.Api.Infrastructure.Data;
using InstaPay.Api.Infrastructure.Settings;
using InstaPay.Api.Services;

using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

ServiceSettings serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>()!;
MongoDbSettings mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>()!;

builder.Services.AddSingleton(serviceProvider =>
{
    var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
    return mongoClient.GetDatabase(serviceSettings.ServiceName);
});

builder.Services.AddSingleton<IRepository<SepaMessage>>(serviceProvider =>
{
    var database = serviceProvider.GetRequiredService<IMongoDatabase>();
    var collectionName = mongoDbSettings.CollectionName;
    return new MongoDbRepository(database, collectionName!);
});

// Register SQL Server repository
builder.Services.AddSingleton<IRepository<SepaBlob>, SqlServerRepository>();

// Injection of MongoDB Payment Service
// builder.Services.AddScoped<IPaymentProcessingService, MongoPaymentProcessingService>();
// Injection of SQL Server Payment service
builder.Services.AddScoped<IPaymentProcessingService, SqlPaymentProcessingService>();

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DataFieldConverter());
                });

var app = builder.Build();
app.MapControllers();
await app.RunAsync();
