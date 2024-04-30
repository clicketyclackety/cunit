using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class InchJsonConverter : JsonConverter<Inch>
	{
		public override Inch Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new Inch(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Inch unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

