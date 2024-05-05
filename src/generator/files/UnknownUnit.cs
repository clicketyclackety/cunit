using System.Reflection;
using generators.files;
using generators.foundations;

namespace generator.units;

public class UnknownUnit : IGenerateableFile
{
    
    protected List<string> Lines { get; } = new();

    public virtual List<string> Generate()
    {
        Lines.Clear();
        Lines.AddRange(GenerateNamespace());
        Lines.AddRange(GenerateClassDeclaration());
        Lines.AddRange(GenerateClassConstants());
        Lines.AddRange(GenerateClassProperties());
        Lines.AddRange(GenerateConstructors());
        Lines.AddRange(GenerateClassMethods());
        Lines.AddRange(GenerateImplicitOperators());
        Lines.AddRange(GenerateEquality());
        Lines.AddRange(GenerateClassFooter());
        Lines.Add(string.Empty);

        return Lines;
    }

    private IEnumerable<string> GenerateClassConstants()
    {
        yield return $"\t/// <summary>Provides a standard erroneous unit></summary>";
        yield return $"\tpublic static {nameof(UnknownUnit)} Err => new(double.NaN);";
        yield return string.Empty;
        yield return $"\t/// <summary>Provides a standard none unit></summary>";
        yield return $"\tpublic static {nameof(UnknownUnit)} None => new(0);";
        yield return string.Empty;
        yield return $"\t/// <summary>The symbol of this <see cref=\"{nameof(UnknownUnit)}\"></summary>";
        yield return $"\tpublic const string Symbol = \"UN\";";
        yield return string.Empty;
    }

    public string GetFilePath()
    {
        Assembly assembly = typeof(GUnit).Assembly;

        var dotnetDir = Path.GetDirectoryName(assembly.Location);
        var configurationDir = Path.GetDirectoryName(dotnetDir);
        var binDir = Path.GetDirectoryName(configurationDir);
        var generatorDir = Path.GetDirectoryName(binDir);
        var srcDir = Path.GetDirectoryName(generatorDir);
        
        return Path.Combine(srcDir, "cunit", $"{nameof(UnknownUnit)}.cs");
    }
    
    public virtual IEnumerable<string> GenerateNamespace()
    {
        yield return "using System.Globalization;";
        yield return "using System.Text.Json.Serialization;";
        yield return string.Empty;
        yield return "using cunit.Json;";
        yield return string.Empty;
        yield return "namespace cunit;";
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GenerateClassDeclaration()
    {
        yield return "/// <summary>";
        yield return $"/// Represents a <see cref=\"{nameof(UnknownUnit)}\"/> Unit.";
        yield return "/// Return a new instance of <see cref=\"UnknownUnit\"/> when you hit a scenario where a unit does not exist.";
        yield return "/// If things didn't go according to plan, return an instance of <see cref=\"UnknownUnit.Err\"/> or <see cref=\"UnknownUnit.None\"/>,";
        yield return "/// rather than throwing an exception or even worse returning a unit with a 0, NaN etc. value that can go undetected.";
        yield return "/// </summary>";
        yield return $"[JsonConverter(typeof(UniversalConverter))]";
        var interfaces = new List<string>()
        {
            $"IUnit",
            "IFormattable",
            $"IEquatable<{nameof(UnknownUnit)}>",
        };

        var classDeclaration = $"public readonly struct {nameof(UnknownUnit)} :\n\t\t\t\t";
        classDeclaration += string.Join(",\n\t\t\t\t", interfaces);
        yield return classDeclaration;
        
        yield return "{";
        yield return string.Empty;
    }

    public virtual IEnumerable<string> GenerateClassProperties()
    {
        yield return $"\tprivate readonly int _preComputedHash = -1;";
        yield return string.Empty;
        
        yield return $"\t/// <summary>The <see cref=\"{Numerics.NumberType}\"/> value of this unit</summary>";
        yield return $"\tpublic {Numerics.NumberType} Value {{ get; }} = double.NaN;";
        
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GenerateConstructors()
    {
        yield return $"\t/// <summary>Creates a new instance of a <see cref=\"{nameof(UnknownUnit)}\"/></summary>";

        yield return $"\tpublic {nameof(UnknownUnit)} () {{}}";
        yield return string.Empty;
        yield return $"\tprivate {nameof(UnknownUnit)}({Numerics.NumberType} value = 1)";
        yield return "\t{";
        yield return "\t\tValue = value;";
        yield return $"\t\t_preComputedHash = {nameof(UnknownUnit).GetHashCode()} ^ Value.GetHashCode();";
        
        yield return "\t}";
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GenerateClassMethods()
    {
        yield break;
    }
    
    // Single Dimensions
    public virtual IEnumerable<string> GenerateImplicitOperators()
    {
        yield return "\t#region Operators";
        yield return string.Empty;
        
        yield return $"\t/// <summary>Converts a <see cref=\"{Numerics.NumberType}\"/> into this <see cref=\"{nameof(UnknownUnit)}\"/>.</summary>";
        yield return $"\tpublic static implicit operator {nameof(UnknownUnit)}({Numerics.NumberType} value) => new (value);";
        yield return string.Empty;
    }

    public virtual IEnumerable<string> GenerateEquality()
    {
        yield return "\t#region Equality";
        yield return string.Empty;

        // Equality and Hashing
        
        string unitOrBaseUnit = nameof(UnknownUnit);
        
        yield return
            $"\t/// <summary>Compares this <see cref=\"{nameof(UnknownUnit)}\"/> with another <see cref=\"{nameof(UnknownUnit)}\"/> for Equality (Constants Tolerance used)</summary>";
        yield return
            $"\tpublic bool Equals({nameof(UnknownUnit)} unit) => Math.Abs(Value - unit.Value) <= cunit.Constants.Tolerance;";
    
        yield return
            $"\t/// <summary>Compares an object with another <see cref=\"{nameof(UnknownUnit)}\"/> for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==({nameof(UnknownUnit)} left, {nameof(UnknownUnit)} right)" +
                     $" => left.Equals(right);";
        yield return
            $"\t/// <summary>Compares this {nameof(UnknownUnit)} with another {nameof(UnknownUnit)} for inequality (no tolerance used)</summary>";
        yield return
            $"\tpublic static bool operator !=(object left, {nameof(UnknownUnit)} right) => !(left == right);";

        yield return
            $"\t/// <summary>Compares an object with another <see cref=\"{nameof(UnknownUnit)}\"/> for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==(object left, {nameof(UnknownUnit)} right)" +
                     $" => left is {nameof(UnknownUnit)} unit && unit.Equals(right);";
        yield return
            $"\t/// <summary>Compares this <see cref=\"{nameof(UnknownUnit)}\"/> with another <see cref=\"{nameof(UnknownUnit)}\"/> for inequality (no tolerance used)</summary>";
        yield return
            $"\tpublic static bool operator !=({nameof(UnknownUnit)} left, {nameof(UnknownUnit)} right) => !(left == right);";

        yield return string.Empty;

        yield return $"\tpublic override int GetHashCode() => _preComputedHash;";
        yield return string.Empty;

        yield return $"\tpublic override bool Equals(object? obj) => obj is {nameof(UnknownUnit)} unit && Equals(unit);";
        yield return string.Empty;

        // TODO : Move to new method

        yield return $"\tpublic override string ToString() => ToString(\"G\");";

        yield return "\tpublic string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);";

        yield return "\tpublic string ToString(string? format, IFormatProvider? formatProvider)";
        yield return "\t\t=> formatProvider switch {";
        yield return
            $"\t\t\t_ => $\"{{Value.ToString(format ?? \"G\", formatProvider ?? CultureInfo.CurrentCulture)}} {{Symbol}}\",";
        yield return "\t\t};";

        yield return string.Empty;
        yield return "\t#endregion";

        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }

    public virtual IEnumerable<string> GenerateClassFooter()
    {
        yield return "}";
        yield return string.Empty;
    }
    
}