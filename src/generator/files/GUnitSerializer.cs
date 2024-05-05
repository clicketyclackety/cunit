using generator.files;
using generators.foundations;

namespace generator.units;

public class UniversalSerializer : IGenerateableFile
{
    
    public string GetFilePath()
        => Path.Combine(FileUtils.GetCunitBaseDirectory(), "json", "UniversalConverter.cs");

    public List<string> Generate()
    {
        return GenerateSerializer().ToList();
    }
    
    private IEnumerable<string> GenerateSerializer()
    {
        yield return "using System.Text.Json;";
        yield return "using System.Text.Json.Serialization;";
        yield return string.Empty;
        yield return string.Empty;
        yield return "namespace cunit.Json";
        yield return "{";
        yield return "\tpublic sealed class UniversalConverter : JsonConverter<IUnit>";
        yield return "\t{";
        yield return string.Empty;
        yield return "\t\tpublic override bool CanConvert(Type typeToConvert) => typeToConvert.GetInterface(nameof(IUnit)) is not null;";
        yield return string.Empty;
        yield return "\t\tpublic override IUnit Read(";
        yield return "\t\t\tref Utf8JsonReader reader,";
        yield return "\t\t\tType typeToConvert,";
        yield return "\t\t\tJsonSerializerOptions options)";
        yield return "\t\t{";
        yield return "\t\t\ttry";
        yield return "\t\t\t{";
        yield return "\t\t\t\tvar value = reader.GetString();";
        yield return "\t\t\t\tvar parts = value?.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();";
        yield return "\t\t\t\tvar symbol = parts.Last();";
        yield return "\t\t\t\tvar dimensions = parts.Take(parts.Count() -1);";
        yield return string.Empty;
        yield return "\t\t\t\tList<double> dimensionValues = new (dimensions.Count());";
        yield return "\t\t\t\tforeach(var doubleString in dimensions)";
        yield return "\t\t\t\t{";
        yield return "\t\t\t\t\tif (string.IsNullOrEmpty(doubleString))";
        yield return "\t\t\t\t\t{";
        yield return "\t\t\t\t\t\tdimensionValues.Add(0);";
        yield return "\t\t\t\t\t\tcontinue;";
        yield return "\t\t\t\t\t}";
        yield return string.Empty;
        yield return "\t\t\t\t\tif (!double.TryParse(doubleString, out var doubleValue))";
        yield return "\t\t\t\t\t{";
        yield return "\t\t\t\t\t\tdimensionValues.Add(0);";
        yield return "\t\t\t\t\t\tcontinue;";
        yield return "\t\t\t\t\t}";
        yield return string.Empty;
        yield return "\t\t\t\t\tdimensionValues.Add(doubleValue);";
        yield return "\t\t\t\t}";
        yield return string.Empty;
        yield return "\t\t\t\tdynamic foundUnit = symbol switch";
        yield return "\t\t\t\t{";

        foreach(var unit in UnitList.GetUnits())
        {
            int dimCount = unit.Dimensions?.Length ?? 1;
            var ints = Enumerable.Range(0, dimCount);
            string args = string.Join(", ", ints.Select(i => $"dimensionValues[{i}]"));
            yield return $"\t\t\t\t\t{unit.Name}.Symbol => new {unit.Name}({args}),";
        }

        yield return "\t\t\t\t\t_ => UnknownUnit.Err";
        yield return "\t\t\t\t};";

        yield return string.Empty;

        yield return "\t\t\t\treturn typeToConvert.Name switch";
        yield return "\t\t\t\t{";
        foreach(var unit in UnitList.GetUnits())
        {
            yield return $"\t\t\t\t\tnameof({unit.Name}) => ({unit.Name})foundUnit,";
        }

        yield return "\t\t\t\t\t_ => UnknownUnit.Err";
        yield return "\t\t\t\t};";
        yield return string.Empty;
        yield return "\t\t\t}";
        yield return "\t\t\tcatch";
        yield return "\t\t\t{";
        yield return "\t\t\t\treturn UnknownUnit.Err;";
        yield return "\t\t\t}";
        yield return "\t\t}";
        yield return string.Empty;
        yield return "\t\tpublic override void Write(";
        yield return "\t\t\tUtf8JsonWriter writer,";
        yield return "\t\t\tIUnit unit,";
        yield return "\t\t\tJsonSerializerOptions options)";
        yield return "\t\t{";
        yield return "\t\t\tstring symbol = unit switch";
        yield return "\t\t\t{";

        foreach(var unit in UnitList.GetUnits())
        {
            yield return $"\t\t\t\t{unit.Name} => {unit.Name}.Symbol,";
        }

        yield return "\t\t\t\t_ => UnknownUnit.Symbol";
        yield return "\t\t\t};";
        yield return string.Empty;
        yield return $"\t\t\tvar json = \"\";";
        yield return string.Empty;
        yield return $"\t\t\tdynamic dynamicUnit = unit;";
        yield return string.Empty;

        for (int i = 2; i < Generics.Names.Length; i++)
        {
            string elseString = i != 2 ? "else " : "";
            yield return $"\t\t\t{elseString}if (unit is IUnit{i}D)";
            yield return "\t\t\t{";
            for (int ii = 0; ii < i; ii++)
            {
                var names = Generics.Names[ii];
                yield return $"\t\t\t\tjson += $\" {{dynamicUnit.{names}Value.Value}}\";";
            }
            yield return "\t\t\t}";
        }

        yield return $"\t\t\telse";
        yield return $"\t\t\t\tjson = $\"{{unit.Value}}\";";
        
        yield return string.Empty;
        yield return $"\t\t\tjson += $\" {{symbol}}\";";

        yield return string.Empty;
        yield return "\t\t\twriter.WriteStringValue(json);";
        yield return string.Empty;
        yield return "\t\t}";
        yield return string.Empty;
        yield return "\t}";
        yield return string.Empty;
        yield return "}";
    }

}