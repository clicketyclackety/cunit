using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class OunceJsonConverter : JsonConverter<Ounce>
	{
		public override Ounce Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new Ounce(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Ounce unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

