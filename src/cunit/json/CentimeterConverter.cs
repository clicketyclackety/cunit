using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class CentimeterJsonConverter : JsonConverter<Centimeter>
	{
		public override Centimeter Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Centimeter(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Centimeter unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

