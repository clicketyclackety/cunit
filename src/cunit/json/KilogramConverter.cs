using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class KilogramJsonConverter : JsonConverter<Kilogram>
	{
		public override Kilogram Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Kilogram(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Kilogram unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

