using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class MillimeterJsonConverter : JsonConverter<Millimeter>
	{
		public override Millimeter Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new Millimeter(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Millimeter unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

