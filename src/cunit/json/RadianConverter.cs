using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class RadianJsonConverter : JsonConverter<Radian>
	{
		public override Radian Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray) reader.Read();

			var value = reader.GetDouble();
			return new Radian(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Radian unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

