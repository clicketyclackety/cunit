using System.Reflection;
using generator.units;
using generators.foundations;
using generators.units;

namespace generators.files;

public sealed class ClassGenerator
{
    private readonly List<string> Lines;
    private UnitList.UnitDescription Unit;
    
    private static readonly string[] genericNames = new[]
    {
        "X", "Y", "Z", "T", "U", "V", "W"
    };

    private static string GetGenericName(int i) => genericNames[i];

    internal ClassGenerator(UnitList.UnitDescription unitDescription)
    {
        Lines = new();
        Unit = unitDescription;
    }

    internal string GetFilePath()
    {
        Assembly assembly = typeof(ClassGenerator).Assembly;

        var dotnetDir = Path.GetDirectoryName(assembly.Location);
        var configurationDir = Path.GetDirectoryName(dotnetDir);
        var binDir = Path.GetDirectoryName(configurationDir);
        var generatorDir = Path.GetDirectoryName(binDir);
        var srcDir = Path.GetDirectoryName(generatorDir);
        
        return Path.Combine(srcDir, "cunit", $"{Unit.Name}.cs");
    }

    public void Generate()
    {
        Lines.AddRange(GenerateNamespace());
        
        Lines.AddRange(GenerateClassHeader());
        Lines.AddRange(GenerateClassProperties());
        Lines.AddRange(GenerateClassConstructors());
        Lines.AddRange(GenerateClassMethods());
        Lines.AddRange(GenerateClassOperators());
        
        Lines.AddRange(GenerateClassFooter());
        
        Lines.Add(string.Empty);
    }
    
    protected IEnumerable<string> GenerateNamespace()
    {
        yield return $"namespace {this.GetType().Namespace.Replace(nameof(generator), "cunit")};";
        yield return string.Empty;
    }
    
    protected IEnumerable<string> GenerateClassHeader()
    {
        yield return "/// <summary>";
        yield return $"/// Represents a {Unit.Name} Unit.";
        yield return "/// </summary>";
        yield return $"public readonly struct {Unit.Name} : IEquatable<{Unit.Name}>";
        yield return "{";
        yield return string.Empty;
    }

    private string GetCalculation()
    {
        string formulae = Unit.Formula?.ToLowerInvariant();
        foreach (var genericName in genericNames)
        {
            string parameterName = $"{genericName.ToUpperInvariant()}Value";
            string varName = genericName.ToLowerInvariant();
            formulae = formulae.Replace($"{varName}{varName}", parameterName);
        }

        return formulae.ToLowerInvariant();
    }
    
    protected IEnumerable<string> GenerateClassProperties()
    {
        // If we have multiple dimensions, this should be more complex
        if (Unit.Dimensions?.Length > 1)
        {
            var names = genericNames[..Unit.Dimensions.Length].Select(g => $"{g}Value");

            yield return $"\tprivate readonly double _preComputedValue = 1;";
            
            yield return "\t/// <summary>The numeric value of this unit</summary>";
            yield return $"\tpublic readonly {Numerics.NumberType} Value => _preComputedValue;";
            yield return string.Empty;
            
            int i = 0;
            foreach(var dimension in Unit.Dimensions)
            {
                yield return "\t/// <summary>The value of this unit</summary>";
                yield return $"\tprivate readonly {dimension} {GetGenericName(i)}Value = 1;";

                i++;
            }
        }
        else
        {
            yield return "\t/// <summary>The double value of this unit</summary>";
            yield return $"\tpublic readonly {Numerics.NumberType} Value = 1;";
        }
        yield return string.Empty;
    }

    protected IEnumerable<string> GenerateClassConstructors()
    {
        // If we have multiple dimensions, this should be more complex
        
        yield return $"\t/// <summary>Creates a new instance of a {Unit.Name}</summary>";
        if (Unit.Dimensions?.Length > 1)
        {
            string[] paramNames = genericNames[..Unit.Dimensions.Length].Select(g => $"{g}Value").ToArray();
            List<string> paramPair = new List<string>();
            for (int i = 0; i < Unit.Dimensions.Length; i++)
            {
                string paramName = paramNames[i].ToLowerInvariant();
                string dimensionName = Unit.Dimensions[i];
                paramPair.Add($"{Numerics.NumberType} {paramName} = 1");
                
                yield return $"\t/// <param name=\"{paramName}\">{Numerics.NumberType}</param>";
            }
            yield return $"\tpublic {Unit.Name}({string.Join(", ", paramPair)})";
            yield return "\t{";
            
            int j = 0;
            foreach(var dimension in Unit.Dimensions)
            {
                yield return $"\t\t{paramNames[j]} = {paramNames[j].ToLowerInvariant()};";
                j++;
            }
            yield return string.Empty;
            yield return $"\t\t_preComputedValue = {GetCalculation()};";
        }
        else
        {
            yield return $"\tpublic {Unit.Name}({Numerics.NumberType} value = 1)";
            yield return "\t{";
            yield return "\t\tValue = value;";
            yield return string.Empty;
        }
        yield return $"\t\t_preComputedHashCode = HashCode.Combine(\"{Unit.Name}\", Value);";
        yield return $"\t\t_preComputedToString = $\"{{Value:0.000}} {Unit.Symbol}\";";
        yield return "\t}";
        yield return string.Empty;
    }

    protected IEnumerable<string> GenerateClassMethods()
    {
        yield return "\t#region Methods";
        yield return string.Empty;

        if (Unit.BaseUnit is not null)
        {
            // TODO : Make this an Interface!
            yield return "\t/// <summary>Converts a unit to SI</summary>";
            yield return $"\tpublic {Unit.BaseUnit.Name} ToSI() => ({Unit.BaseUnit.Name})this;";
            yield return string.Empty;
        }

        yield return "\t#endregion";
        yield return string.Empty;
    }

    private static char[] operators = new[] { '/', '*', '-', '+' };
    
    // Single Dimensions
    protected IEnumerable<string> GenerateClassOperators()
    {
        yield return "\t#region Operators";
        yield return string.Empty;
        
        // Double to Type
        yield return "\t#region Casting";
        yield return string.Empty;
        
        yield return $"\t/// <summary>Converts a {Numerics.NumberType} into this Unit.</summary>";
        yield return $"\tpublic static implicit operator {Unit.Name}({Numerics.NumberType} value) => new {Unit.Name}(value);";
        yield return string.Empty;

        if (Unit.BaseUnit is not null)
        {
            yield return $"\t/// <summary>Converts a {Unit.BaseUnit.Name} into this Unit.</summary>";
            yield return $"\tpublic static implicit operator {Unit.BaseUnit.Name}({Unit.Name} value) => new {Unit.BaseUnit.Name}(value * {Unit.Ratio});";
            yield return string.Empty;
            
            yield return $"\t/// <summary>Converts a {Unit.Name} into a {Unit.BaseUnit.Name}.</summary>";
            yield return $"\tpublic static implicit operator {Unit.Name}({Unit.BaseUnit.Name} value) => new {Unit.Name}(value / {Unit.Ratio});";
            yield return string.Empty;
        }
        
        /*
        // Get mulitpliers, create operators between operators
        FieldInfo[] multis = Writer.GetConstants(typeof(BaseTenPrefixes))
                                .Where(m => !m.Name.Contains(nameof(BaseTenPrefixes.Singular)))
                                .Where(m => !m.Name.Contains(Unit.Name))
                                .ToArray();

        if(!Unit.BaseUnit.Name.ToLowerInvariant().StartsWith(Unit.Name.ToLowerInvariant()))
        {
            yield return $"\tpublic static implicit operator {Unit.Name}({Unit.BaseUnit.Name} value) => new {Unit.Name}(value / {Unit.Multiplier.GetValue(null)});";
        }

        foreach (var multi in multis)
        {
            var multiName = $"{multi.Name}{Unit.BaseUnit.Name.ToLowerInvariant()}";
            if (multiName == Unit.Name)
                continue;

            yield return
                $"\tpublic static implicit operator {Unit.Name}({multiName} value) => new {Unit.Name}(value * {multi.GetValue(null)} / {Unit.Multiplier.GetValue(null)});";
        }

        // Tuple Operators
        foreach (var dimUnit in Unit.Dimensions)
        {
            // Duplication?
            foreach (var compatDims in dimUnit.CompatibleDimensions)
            {
                if (compatDims.Length <= 1)
                    continue;

                string opString = $"\tpublic static implicit operator (";
                string tuples = string.Join(", ", compatDims.Select(cd => Writer.UnitLookup[cd].Name));
                opString += tuples;
                var value = Unit.Multiplier.GetValue(null);
                opString += $") ({Unit.Name} value) => new ValueTuple<{tuples}>(value * {value}, value * {value});";

                yield return opString;
            }
        }

        */

        yield return "\t#endregion";
        
        // More complexity now!
        yield return string.Empty;
        
        yield return "\t#region Mathmatic Operators";
        yield return string.Empty;
        
        // Maths
        string[] mathmaticOperators = new string[] { "+", "-", "/", "*" };
        
        foreach(var @operator in mathmaticOperators)
        {
            yield return string.Empty;
            yield return $"\tpublic static {Numerics.NumberType} operator {@operator}({Unit.Name} left, {Unit.Name} right)" + 
                         $"=> left.Value {@operator} right.Value;";
        }

        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
        
        // Positive & Negative
        yield return "\t#region Positive / Negative Operators";
        yield return string.Empty;
        
        yield return string.Empty;
        yield return $"\tpublic static {Unit.Name} operator +({Unit.Name} val) => val;"; // Positive
        yield return string.Empty;
        yield return $"\tpublic static {Unit.Name} operator -({Unit.Name} val) => new (-val.Value);"; // Negative
        
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
        
        yield return "\t#region Greater/Less";
        yield return string.Empty;
        
        // Greater, Less Than etc.
        string[] gtolt = new string[] { "<", ">", "<=", ">=" };
        foreach (var statement in gtolt)
        {
            yield return string.Empty;
            yield return $"\tpublic static bool operator {statement}({Unit.Name} left, {Unit.Name} right)" +
            $" => left.Value {statement} right.Value;";
        }
        
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;

        yield return "\t#region Equality";
        yield return string.Empty;
        
        // Equality and Hashing
        yield return $"\t/// <summary>Compares this {Unit.Name} with another {Unit.Name} for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==({Unit.Name} left, {Unit.Name} right)" +
                    $" => left.Equals(right);";
        
        yield return $"\t/// <summary>Compares this {Unit.Name} with another {Unit.Name} for inequality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator !=({Unit.Name} left, {Unit.Name} right) => !(left == right);";
        yield return string.Empty;
        
        // TODO : Needs to handle Multi-dimension objects
        
        
        
        yield return string.Empty;
        yield return $"\tprivate readonly int _preComputedHashCode = -1;";
        yield return $"\tpublic override int GetHashCode() => _preComputedHashCode;";
        yield return string.Empty;
        yield return $"\tpublic override bool Equals(object? obj) => obj is {Unit.Name} unit && Equals(unit);";
        yield return string.Empty;
        yield return $"\tpublic bool Equals({Unit.Name} unit) => (this.Value / unit.Value) - 0.0001 <= 0;";
        yield return string.Empty;
        yield return "\tprivate readonly string _preComputedToString = \"Unset\";"; 
        yield return $"\tpublic override string ToString() => _preComputedToString;";

        yield return string.Empty;
        yield return "\t#endregion";
        
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }
    
    protected IEnumerable<string> GenerateClassFooter()
    {
        yield return "}";
        yield return string.Empty;
    }

    public IReadOnlyCollection<string> GetLines() => Lines;

}