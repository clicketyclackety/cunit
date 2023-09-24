using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class FarenheightJsonConverter : JsonConverter<Farenheight>
	{
		public override Farenheight Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Farenheight(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Farenheight unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

