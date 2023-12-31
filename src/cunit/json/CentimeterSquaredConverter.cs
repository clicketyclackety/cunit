using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class CentimeterSquaredJsonConverter : JsonConverter<CentimeterSquared>
	{
		public override CentimeterSquared Read(
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

			return new CentimeterSquared(xvalue, yvalue);
		}

		public override void Write(
			Utf8JsonWriter writer,
			CentimeterSquared unit,
			JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			writer.WriteNumberValue(unit.XValue.Value);
			writer.WriteNumberValue(unit.YValue.Value);
			writer.WriteEndArray();
		}
	}
}

