using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class WeekJsonConverter : JsonConverter<Week>
	{
		public override Week Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Week(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Week unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

