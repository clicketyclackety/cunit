using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class GramJsonConverter : JsonConverter<Gram>
	{
		public override Gram Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Gram(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Gram unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

