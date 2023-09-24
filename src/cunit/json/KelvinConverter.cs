using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class KelvinJsonConverter : JsonConverter<Kelvin>
	{
		public override Kelvin Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Kelvin(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Kelvin unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

