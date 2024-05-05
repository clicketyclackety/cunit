using generator.units;
using generators.foundations;

namespace generator.files;

// TODO : Implement INumber<T>?
public class UnitInterfaceFile : IGenerateableFile
{

    private List<string> lines = new();
    
    public string GetFilePath()
        => Path.Combine(FileUtils.GetCunitBaseDirectory(), "IUnit.cs");

    public List<string> Generate()
    {
        lines.AddRange(GenerateBaseInterfaces());
        lines.AddRange(GenerateMultiDimensionalInterfaces());

        return lines;
    }

    private static IEnumerable<string> GenerateBaseInterfaces()
    {
        yield return "namespace cunit;";
        yield return string.Empty;
        yield return "/// <summary>Defines a Unit</summary>";
        yield return "public interface IUnit";
        yield return "{";
        yield return "    /// <summary>The numeric value of this unit</summary>";
        yield return "    public double Value { get; }";
        yield return "}";
        yield return string.Empty;
        yield return "/// <summary>Defines a Unit with SI Conversion</summary>";
        yield return "public interface IUnit<TSi> : IUnit";
        yield return "{";
        yield return "    /// <summary>Converts to an SI Unit</summary>";
        yield return "    /// <returns>An SI Unit</returns>";
        yield return "    public TSi ToSI();";
        yield return "}";
        yield return string.Empty;
    }

    private IEnumerable<string> GenerateMultiDimensionalInterfaces()
    {
        yield return "/// <summary>Defines a 2D Unit</summary>";

        for (int i = 2; i < Generics.Names.Length; i++)
        {
            var names = Generics.Names[..i];

            var genericItems = names.Select(n => $"{n}Unit");
            string genericNames = string.Join(", ", genericItems);
            yield return $"public interface IUnit<{genericNames}> : IUnit{i}D";
            yield return "{";
            for(int j = 0; j < names.Length; j++)
            {
                string g = names[j].ToUpperInvariant();
                yield return $"\t/// <summary>{g} Dimension Unit</summary>";
                yield return $"\tpublic {g}Unit {g}Value {{ get; }}";
            }
            yield return "}";
            yield return string.Empty;

            yield return $"public interface IUnit{i}D : IUnit {{}}";
            yield return string.Empty;
        }
        
    }
}