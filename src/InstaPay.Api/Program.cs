using InstaPay.Api.Infrastructure.Converters;
using InstaPay.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DataFieldConverter());
                });

var app = builder.Build();
app.MapControllers();
await app.RunAsync();
