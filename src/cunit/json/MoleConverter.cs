using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class MoleJsonConverter : JsonConverter<Mole>
	{
		public override Mole Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Mole(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Mole unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

