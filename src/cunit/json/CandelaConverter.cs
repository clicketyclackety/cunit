using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class CandelaJsonConverter : JsonConverter<Candela>
	{
		public override Candela Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new Candela(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Candela unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

