using generator.units;

namespace generators.foundations;

public class Generics
{
    public static readonly string[] Names = new[]
    {
        "X", "Y", "Z", "T", "U", "V", "W"
    };

    private static string GetParam(string genericName) => $"{genericName}Value";
    
    public static string GetParam(int index) => $"{Names[index]}Value";
    
    public static string[] GetUnitNames(UnitList.UnitDescription unit)
        => unit.Dimensions is null ? Array.Empty<string>() : Names[..unit.Dimensions.Length];

    public static string[] GetUnitParameterNames(UnitList.UnitDescription unit)
        => GetUnitNames(unit).Select(g => GetParam(g)).ToArray();

    public static IEnumerable<(string Dim, string Param)> GetUnitTypeParameterPairs(UnitList.UnitDescription unit)
    {
        for (int i = 0; i < unit.Dimensions.Length; i++)
        {
            string dim = unit.Dimensions[i];
            string param = GetParam(Names[i]);

            yield return new (dim, param);
        }
    }
    
}