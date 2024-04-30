using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class MeterCubedJsonConverter : JsonConverter<MeterCubed>
	{
		public override MeterCubed Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			reader.TryGetDouble(out double xvalue);
			reader.Read();

			reader.TryGetDouble(out double yvalue);
			reader.Read();

			reader.TryGetDouble(out double zvalue);
			reader.Read();

			return new MeterCubed(xvalue, yvalue, zvalue);
		}

		public override void Write(
			Utf8JsonWriter writer,
			MeterCubed unit,
			JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			writer.WriteNumberValue(unit.XValue.Value);
			writer.WriteNumberValue(unit.YValue.Value);
			writer.WriteNumberValue(unit.ZValue.Value);
			writer.WriteEndArray();
		}
	}
}

