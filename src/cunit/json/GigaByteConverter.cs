using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class GigaByteJsonConverter : JsonConverter<GigaByte>
	{
		public override GigaByte Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new GigaByte(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			GigaByte unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

