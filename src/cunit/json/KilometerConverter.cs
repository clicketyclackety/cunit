using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class KilometerJsonConverter : JsonConverter<Kilometer>
	{
		public override Kilometer Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Kilometer(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Kilometer unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

