using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class FahrenheitJsonConverter : JsonConverter<Fahrenheit>
	{
		public override Fahrenheit Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new Fahrenheit(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Fahrenheit unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

