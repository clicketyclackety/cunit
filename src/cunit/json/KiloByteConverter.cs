using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class KiloByteJsonConverter : JsonConverter<KiloByte>
	{
		public override KiloByte Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new KiloByte(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			KiloByte unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

