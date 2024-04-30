using System.Reflection;
using generator.files;
using generators.foundations;

namespace generator.units;

public class GUnitSerializer : IGenerateableFile
{

    public readonly GUnit Unit;

    public GUnitSerializer(GUnit unit)
    {
        Unit = unit;
    }
    
    public string GetFilePath()
        => Path.Combine(FileUtils.GetCunitBaseDirectory(), "json", $"{Unit.Name}Converter.cs");

    public List<string> Generate()
    {
        return GenerateSerializer().ToList();
    }
    
    private IEnumerable<string> GenerateSerializer()
    {
        yield return "using System.Text.Json;";
        yield return "using System.Text.Json.Serialization;";
        yield return string.Empty;
        yield return "namespace cunit.Json";
        yield return "{";
        yield return $"\tpublic sealed class {Unit.Name}JsonConverter : JsonConverter<{Unit.Name}>";
        yield return "\t{";
        yield return $"\t\tpublic override {Unit.Name} Read(";
        yield return "\t\t\tref Utf8JsonReader reader,";
        yield return "\t\t\tType typeToConvert,";
        yield return "\t\t\tJsonSerializerOptions options)";
        yield return "\t\t{";

        if (Unit.Dimensions is not null)
        {
            yield return "\t\t\tif (reader.TokenType == JsonTokenType.StartArray) reader.Read();";
            yield return string.Empty;
        }
        
        if (Unit.Dimensions is null)
        {
            yield return $"\t\t\tvar value = reader.Get{ToTitleCase(Numerics.NumberType)}();";
            yield return $"\t\t\treturn new {Unit.Name}(value);";
        }
        else
        {
            List<string> parameters = new(Unit.Dimensions.Length);
            for(int i = 0; i < Unit.Dimensions.Length; i++)
            {
                yield return $"\t\t\treader.TryGet{ToTitleCase(Numerics.NumberType)}(out {Numerics.NumberType} {Generics.GetParam(i).ToLowerInvariant()});";
                yield return "\t\t\treader.Read();";
                yield return string.Empty;
                
                parameters.Add(Generics.GetParam(i).ToLowerInvariant());
            }
            
            // yield return "\t\t\tif (reader.TokenType == JsonTokenType.EndArray) reader.Read();"; 
            // yield return string.Empty;
            yield return $"\t\t\treturn new {Unit.Name}({string.Join(", ", parameters)});";
        }
        yield return "\t\t}";
        yield return string.Empty;
        yield return "\t\tpublic override void Write(";
        yield return "\t\t\tUtf8JsonWriter writer,";
        yield return $"\t\t\t{Unit.Name} unit,";
        yield return "\t\t\tJsonSerializerOptions options)";
        yield return "\t\t{";
        if (Unit.Dimensions is null)
        {
            yield return "\t\t\twriter.WriteNumberValue(unit.Value);";
        }
        else
        {
            yield return $"\t\t\twriter.WriteStartArray();";
            for(int i = 0; i < Unit.Dimensions.Length; i++)
            {
                yield return $"\t\t\twriter.WriteNumberValue(unit.{Generics.GetParam(i)}.Value);";
            }
            yield return $"\t\t\twriter.WriteEndArray();";
        }
        yield return "\t\t}";
        yield return "\t}";
        yield return "}";
        yield return string.Empty;
    }
    
    private string ToTitleCase(string value)
    {
        string val = value.ToLowerInvariant();
        return $"{val[0].ToString().ToUpperInvariant()}{val[1..]}";
    }

}