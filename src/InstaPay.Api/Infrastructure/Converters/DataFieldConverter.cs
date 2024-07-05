using System.Text.Json;
using System.Text.Json.Serialization;
using InstaPay.Api.Controllers.Dtos;

namespace InstaPay.Api.Infrastructure.Converters;

public class DataFieldConverter : JsonConverter<IDataField>
{
    public override IDataField? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement root = document.RootElement;

        if (root.TryGetProperty("PACS008", out _))
        {
            return JsonSerializer.Deserialize<Pacs008DataField>(root.GetRawText(), options);
        }
        else if (root.TryGetProperty("PACS002", out _))
        {
            return JsonSerializer.Deserialize<Pacs002DataField>(root.GetRawText(), options);
        }
        else
        {
            throw new JsonException("unknown data type");
        }
    }

    public override void Write(Utf8JsonWriter writer, IDataField value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}