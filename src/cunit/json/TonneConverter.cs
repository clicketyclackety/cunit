using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class TonneJsonConverter : JsonConverter<Tonne>
	{
		public override Tonne Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new Tonne(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Tonne unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

