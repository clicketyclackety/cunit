using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class MillimeterSquaredJsonConverter : JsonConverter<MillimeterSquared>
	{
		public override MillimeterSquared Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			reader.TryGetDouble(out double xvalue);
			reader.Read();

			reader.TryGetDouble(out double yvalue);
			reader.Read();

			if (reader.TokenType == JsonTokenType.EndArray) reader.Read();

			return new MillimeterSquared(xvalue, yvalue);
		}

		public override void Write(
			Utf8JsonWriter writer,
			MillimeterSquared unit,
			JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			writer.WriteNumberValue(unit.XValue.Value);
			writer.WriteNumberValue(unit.YValue.Value);
			writer.WriteEndArray();
		}
	}
}

