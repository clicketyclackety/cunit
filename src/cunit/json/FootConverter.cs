using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class FootJsonConverter : JsonConverter<Foot>
	{
		public override Foot Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Foot(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Foot unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

