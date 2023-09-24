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
    
    public static string[] GetUnitNames(GUnit gUnit)
        => gUnit.Dimensions is null ? Array.Empty<string>() : Names[..gUnit.Dimensions.Length];

    public static string[] GetUnitParameterNames(GUnit gUnit)
        => GetUnitNames(gUnit).Select(g => GetParam(g)).ToArray();

    public static IEnumerable<(string Dim, string Param)> GetUnitTypeParameterPairs(GUnit gUnit)
    {
        for (int i = 0; i < gUnit.Dimensions.Length; i++)
        {
            string dim = gUnit.Dimensions[i];
            string param = GetParam(Names[i]);

            yield return new (dim, param);
        }
    }
    
}