using generators.units;

namespace generators;

public abstract class GeneratableUnit : IGeneratableUnit
{
    
    public UnitType Type { get; protected set; }
    public UnitType[][] CompatibleDimensions { get; protected set; }

    public string Name { get; set; }

    // TODO : Remove
    public string ValueType { get; protected set; } = "double";
    public string DefaultValue { get; protected set; } = "1.0";
    
    public string UnitSymbol { get; protected set; }
    public string DimensionSymbol { get; protected set; }

    public void Generate(out List<string> lines)
    {
        lines = new();
        
        lines.AddRange(GenerateNamespace());
        
        lines.AddRange(GenerateClassHeader());
        lines.AddRange(GenerateClassProperties());
        lines.AddRange(GenerateClassConstructors());
        lines.AddRange(GenerateClassMethods());
        lines.AddRange(GenerateClassOperators());
        lines.AddRange(GenerateClassFooter());
        
        lines.Add(string.Empty);
    }

    protected virtual IEnumerable<string> GenerateClassProperties()
    {
        yield return $"\tpublic readonly {ValueType} _value;";
        yield return string.Empty;
        yield break;
    }

    protected virtual IEnumerable<string> GenerateClassConstructors()
    {
        yield return $"\tpublic {Name}({ValueType} value)";
        yield return "\t{";
        yield return "\t\t_value = value;";
        yield return "\t}";
        yield return string.Empty;
    }

    protected virtual IEnumerable<string> GenerateClassMethods()
    {
        yield break;
    }

    // Single Dimensions
    protected virtual IEnumerable<string> GenerateClassOperators()
    {
        // Double to Type
        yield return $"\tpublic static implicit operator {Name}({ValueType} value) => new(value);";
        yield return string.Empty;
    }

    protected IEnumerable<string> GenerateNamespace()
    {
        yield return $"namespace {this.GetType().Namespace.Replace(nameof(generator), "cunit")};";
        yield return string.Empty;
    }
    
    protected IEnumerable<string> GenerateClassHeader()
    {
        yield return $"public struct {Name}";
        yield return "{";
        yield return string.Empty;
    }
    
    protected IEnumerable<string> GenerateClassFooter()
    {
        yield return "}";
        yield return string.Empty;
    }
    
}
