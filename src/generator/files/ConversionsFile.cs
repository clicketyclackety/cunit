using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using generator.units;
using generators.foundations;

namespace generator.files
{
    public class ConversionsFile : IGenerateableFile
    {
        public List<string> Generate()
        {
            var strings = new List<string>();
            strings.AddRange(GenerateFromStringConversions());
            strings.AddRange(GenerateToStringConversions());
            return strings;
        }

        public string GetFilePath()
        => Path.Combine(FileUtils.GetCunitBaseDirectory(), "Conversions.cs");

        private IEnumerable<string> GenerateFromStringConversions()
        {
            yield return "using System.Text.Json;";
            yield return "using System.Text.Json.Serialization;";
            yield return string.Empty;
            yield return "namespace cunit.Json";
            yield return "{";
            yield return string.Empty;
            yield return "\tpublic class Conversions";
            yield return "\t{";
            yield return string.Empty;
            yield return "\t\tpublic bool Convert(string? value, Type typeToConvert, out IUnit unit)";
            yield return "\t\t{";
            yield return "\t\t\ttry";
            yield return "\t\t\t{";
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

            yield return "\t\t\t\tunit = typeToConvert.Name switch";
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
            yield return "\t\t\t\tunit = UnknownUnit.Err;";
            yield return "\t\t\t}";
            yield return string.Empty;
            yield return "\t\t\treturn unit != UnknownUnit.Err;";
            yield return string.Empty;
            yield return "\t\t}";
        }

        private IEnumerable<string> GenerateToStringConversions()
        {
            yield return string.Empty;
            yield return "\t\tpublic bool Convert(IUnit unit, out string? value)";
            yield return "\t\t{";
            yield return "\t\t\tvalue = string.Empty;";
            yield return "\t\t\ttry";
            yield return "\t\t\t{";
            yield return "\t\t\t\tstring symbol = unit switch";
            yield return "\t\t\t\t{";

            foreach(var unit in UnitList.GetUnits())
            {
                yield return $"\t\t\t\t\t{unit.Name} => {unit.Name}.Symbol,";
            }

            yield return "\t\t\t\t\t_ => UnknownUnit.Symbol";
            yield return "\t\t\t\t};";
            yield return string.Empty;
            yield return $"\t\t\t\tvar json = string.Empty;";
            yield return string.Empty;
            yield return $"\t\t\t\tdynamic dynamicUnit = unit;";
            yield return string.Empty;

            for (int i = 2; i < Generics.Names.Length; i++)
            {
                string elseString = i != 2 ? "else " : "";
                yield return $"\t\t\t\t{elseString}if (unit is IUnit{i}D)";
                yield return "\t\t\t\t{";
                for (int ii = 0; ii < i; ii++)
                {
                    var names = Generics.Names[ii];
                    yield return $"\t\t\t\t\tjson += $\" {{dynamicUnit.{names}Value.Value}}\";";
                }
                yield return "\t\t\t\t}";
            }

            yield return $"\t\t\t\telse";
            yield return $"\t\t\t\t\tjson = $\"{{unit.Value}}\";";
            
            yield return string.Empty;
            yield return $"\t\t\t\tjson += $\" {{symbol}}\";";

            yield return string.Empty;
            yield return "\t\t\t\tvalue = json;";
            yield return string.Empty;
            yield return "\t\t\t}";
            yield return "\t\t\tcatch {";
            yield return "\t\t\t\treturn false;";
            yield return "\t\t\t}";
            yield return string.Empty;
            yield return "\t\t\treturn !string.IsNullOrEmpty(value);";
            yield return "\t\t}";
            yield return string.Empty;
            yield return "\t}";
            yield return string.Empty;
            yield return "}";
            yield return string.Empty;
        }

    }
}