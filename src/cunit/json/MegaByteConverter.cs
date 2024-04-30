using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class MegaByteJsonConverter : JsonConverter<MegaByte>
	{
		public override MegaByte Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new MegaByte(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			MegaByte unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

