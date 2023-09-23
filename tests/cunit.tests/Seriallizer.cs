using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit
{
    public sealed class MeterJsonConverter : JsonConverter<Meter>
    {
        public override Meter Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var value = reader.GetDouble();
            return new Meter(value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Meter meter,
            JsonSerializerOptions options)
        {
            writer.WriteNumberValue(meter.Value);
        }
    }
}