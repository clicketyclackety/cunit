using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class ByteJsonConverter : JsonConverter<Byte>
	{
		public override Byte Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Byte(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Byte unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

