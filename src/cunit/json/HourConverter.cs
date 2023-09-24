using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class HourJsonConverter : JsonConverter<Hour>
	{
		public override Hour Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Hour(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Hour unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

