using System.Reflection;
using generator.units;

namespace generator.files;

public sealed class ConstantsFile : IGenerateableFile
{
    
    public string GetFilePath()
        => Path.Combine(FileUtils.GetCunitBaseDirectory(), "Constants.cs");

    public List<string> Generate() => GenerateFile().ToList();

    private IEnumerable<string> GenerateFile()
    {
        yield return "namespace cunit;";
        yield return string.Empty;
        yield return "public static class Constants";
        yield return "{";
        yield return "    public static double Tolerance { get; set; } = 0.0001;";
        yield return string.Empty;
        yield return "    public const double PI = Math.PI;";
        yield return "    public const double TAU = PI * 2;";
        yield return string.Empty;
        yield return "}";
    }
}