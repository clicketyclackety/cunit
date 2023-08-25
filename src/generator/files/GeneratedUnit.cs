using System.Reflection;
using generator.units;
using generator.units.constants;

namespace generators.files;

internal sealed  class GeneratedUnit
{

    private static string[] dimensionStrings = new string[]
    {
        string.Empty,
        string.Empty,
        "Squared",
        "Cubed",
        "Multi","Multi","Multi","Multi","Multi","Multi","Multi","Multi","Multi",
    };
    
    public readonly IGeneratableUnit BaseUnit;
    public readonly string Name;
    public readonly string Namespace;
    public readonly string FilePath;
    public readonly FieldInfo Multiplier;
    public readonly IUnit[] Dimensions;
    
    internal GeneratedUnit(IGeneratableUnit baseUnit, FieldInfo multiplier, IUnit[] dimensions)
    {
        BaseUnit = baseUnit;
        Multiplier = multiplier;
        Dimensions = dimensions;
        
        Name = GetName();
        FilePath = GetFilePath();
        Namespace = GetNamespace();
    }
    internal string GetName()
    {
        string prefix = Multiplier.Name;
        string adjustedName = BaseUnit.Name.ToLowerInvariant();
        string suffix = dimensionStrings[Dimensions.Length];

        if (prefix.ToLowerInvariant().Contains(nameof(BaseTenPrefixes.Singular).ToLowerInvariant()) &&
            string.IsNullOrEmpty(suffix))
        {
            return BaseUnit.Name;
        }

        string name = $"{prefix}{adjustedName}";

        if (!string.IsNullOrEmpty(suffix))
        {
            name += $"_{suffix}";
        }
        
        return name;
    }

    internal string GetNamespace() => $"namespace cunit.{BaseUnit.Name};";

    internal string GetFilePath() =>  Path.Combine(BasePath, $"{Name}.cs");

    private string _basePath { get; set; }

    private string BasePath
    {
        get
        {
            if (string.IsNullOrEmpty(_basePath))
            {
                Assembly assembly = typeof(IGeneratableUnit).Assembly;

                var dotnetDir = Path.GetDirectoryName(assembly.Location);
                var configurationDir = Path.GetDirectoryName(dotnetDir);
                var binDir = Path.GetDirectoryName(configurationDir);
                var generatorDir = Path.GetDirectoryName(binDir);
                var srcDir = Path.GetDirectoryName(generatorDir);
                _basePath = Path.Combine(srcDir, "cunit");
            }

            return _basePath;
        }
    }

    public override string ToString() => GetName();
}