using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace generators.units.volume;

public class DimensionedUnit : IGeneratable
{
    public string Name { get; set; }
    public int Dimensions { get; set; }

    private char[] s_dims = new char[] { 'X', 'Y', 'Z', 'U', 'V', 'W' };

    public DimensionedUnit()
    {
        Name = "Dimensions";
        Dimensions = 5;
    }
    
    public DimensionedUnit(string name, int dimensions)
    {
        Name = name;
        // TODO : Maximum size check
        Dimensions = dimensions;
    }
    
    public void Generate(out List<string> lines)
    {
        lines = new();
        
        var unitArgs = s_dims.Select(s => $"{s}Unit").ToArray();
        var unitArgsFormatted = string.Join(", ", s_dims.Select(s => $"{s}Unit"));
        lines.Add($"public sealed class {Name}<{unitArgsFormatted}>"); //) where {unitArgsFormatted} : IUnit";
        lines.Add("{");
        lines.Add(string.Empty);
        for (int d = 0; d < Dimensions; d++)
        {
            lines.Add($"\tpublic readonly {unitArgs[d]} {s_dims[d]};");
        }
        lines.Add(string.Empty);

        string unitArgsAsArgs = string.Join(", ", unitArgs.Select(ua => $"{ua} {ua[0].ToString().ToLowerInvariant()}"));
        lines.Add($"\tpublic {Name}({unitArgsAsArgs})");
        lines.Add("\t{");
        for (int d = 0; d < Dimensions; d++)
        {
            lines.Add($"\t\t{s_dims[d]} = {s_dims[d].ToString().ToLowerInvariant()};");
        }
        lines.Add("\t}");
        lines.Add("}");
        lines.Add(string.Empty);
    }
}
