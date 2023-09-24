using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class MeterJsonConverter : JsonConverter<Meter>
	{
		public override Meter Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Meter(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Meter unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

