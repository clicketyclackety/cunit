using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class PoundJsonConverter : JsonConverter<Pound>
	{
		public override Pound Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Pound(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Pound unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

