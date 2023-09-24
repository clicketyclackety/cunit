using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class SecondJsonConverter : JsonConverter<Second>
	{
		public override Second Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Second(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Second unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

