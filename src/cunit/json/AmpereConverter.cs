using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class AmpereJsonConverter : JsonConverter<Ampere>
	{
		public override Ampere Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Ampere(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Ampere unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

