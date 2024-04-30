using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class DayJsonConverter : JsonConverter<Day>
	{
		public override Day Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new Day(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Day unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

