using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class MilliSecondJsonConverter : JsonConverter<MilliSecond>
	{
		public override MilliSecond Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new MilliSecond(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			MilliSecond unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

