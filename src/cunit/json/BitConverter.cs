using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class BitJsonConverter : JsonConverter<Bit>
	{
		public override Bit Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Bit(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Bit unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

