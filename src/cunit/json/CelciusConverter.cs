using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class CelciusJsonConverter : JsonConverter<Celcius>
	{
		public override Celcius Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Celcius(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Celcius unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

