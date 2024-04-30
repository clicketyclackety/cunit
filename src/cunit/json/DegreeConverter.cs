using System.Text.Json;
using System.Text.Json.Serialization;

namespace cunit.Json
{
	public sealed class DegreeJsonConverter : JsonConverter<Degree>
	{
		public override Degree Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var value = reader.GetDouble();
			return new Degree(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			Degree unit,
			JsonSerializerOptions options)
		{
			writer.WriteNumberValue(unit.Value);
		}
	}
}

