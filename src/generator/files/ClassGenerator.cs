using System.Reflection;
using generator.units;
using generator.units.constants;
using generator.units.si;
using generators.foundations;
using generators.units;

namespace generators.files;

public sealed class ClassGenerator
{
    private readonly List<string> Lines;
    private GeneratedUnit Unit;

    internal ClassGenerator(GeneratedUnit generatedUnit)
    {
        Lines = new();
        Unit = generatedUnit;
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
        yield return $"/// Represents a {Unit.GetName()} Unit.";
        yield return "/// </summary>";
        yield return $"public readonly struct {Unit.GetName()} : IEquatable<{Unit.GetName()}>";
        yield return "{";
        yield return string.Empty;
    }
    
    protected IEnumerable<string> GenerateClassProperties()
    {
        
        yield return "\t/// <summary>The double value of this unit</summary>";
        yield return $"\tinternal readonly {numerics.NumberType} Value;";
        yield return string.Empty;
        yield break;
    }

    protected IEnumerable<string> GenerateClassConstructors()
    {
        yield return $"\t/// <summary>Creates a new instance of a {Unit.GetName()}";
        yield return $"\tpublic {Unit.GetName()}({numerics.NumberType} value)";
        yield return "\t{";
        yield return "\t\tValue = value;";
        yield return "\t}";
        yield return string.Empty;
    }

    protected IEnumerable<string> GenerateClassMethods()
    {
        yield return "\t#region Methods";
        yield return string.Empty;
        yield return "\t/// <summary>Converts a unit to SI</summary>";
        yield return $"\tpublic {nameof(Meter)} ToSI() => ({nameof(Meter)})this;";
        yield return string.Empty;
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
        
        yield return $"\t/// <summary>Converts a {numerics.NumberType} into this Unit.</summary>";
        yield return $"\tpublic static implicit operator {Unit.GetName()}({numerics.NumberType} value) => new {Unit.Name}(value);";

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

        yield return "\t#endregion";
        
        // More complexity now!
        yield return string.Empty;
        
        yield return "\t#region Mathmatic Operators";
        yield return string.Empty;
        
        // Maths
        string[] mathmaticOperators = new string[] { "+", "-", "/", "*" };
        
        foreach(var @operator in mathmaticOperators)
        {
            yield return $"\t///<inheritdoc/>";
            yield return $"\tpublic static {numerics.NumberType} operator {@operator}({Unit.GetName()} left, {Unit.GetName()} right)" + 
                         $"=> left.Value {@operator} right.Value;";
        }

        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
        
        // Positive & Negative
        yield return "\t#region Positive / Negative Operators";
        yield return string.Empty;
        
        yield return $"\t///<inheritdoc/>";
        yield return $"\tpublic static {Unit.GetName()} operator +({Unit.GetName()} val) => val;"; // Positive
        yield return $"\t///<inheritdoc/>";
        yield return $"\tpublic static {Unit.GetName()} operator -({Unit.GetName()} val) => new (-val.Value);"; // Negative
        
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
        
        yield return "\t#region Greater/Less";
        yield return string.Empty;
        
        // Greater, Less Than etc.
        string[] gtolt = new string[] { "<", ">", "<=", ">=" };
        foreach (var statement in gtolt)
        {
            yield return $"\t///<inheritdoc/>";
            yield return $"\tpublic static bool operator {statement}({Unit.GetName()} left, {Unit.GetName()} right)" +
            $" => left.GetHashCode() {statement} right.GetHashCode();";
        }
        
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;

        yield return "\t#region Equality";
        yield return string.Empty;
        
        // Equality and Hashing
        yield return $"\t/// <summary>Compares this {Unit.GetName()} with another {Unit.GetName()} for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==({Unit.GetName()} left, {Unit.GetName()} right)" +
                    $"=> left.GetHashCode() == right.GetHashCode();";
        
        yield return $"\t/// <summary>Compares this {Unit.GetName()} with another {Unit.GetName()} for inequality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator !=({Unit.GetName()} left, {Unit.GetName()} right) => !(left == right);";
        yield return string.Empty;
        
        // TODO : Needs to handle Multi-dimension objects
        yield return $"\t///<inheritdoc/>";
        yield return $"\tpublic override int GetHashCode() => HashCode.Combine(this.Value);";
        yield return $"\t///<inheritdoc/>";
        yield return $"\tpublic override bool Equals(object? obj) => obj is {Unit.GetName()} unit && Equals(unit);";
        yield return $"\t///<inheritdoc/>";
        yield return $"\tpublic bool Equals({Unit.GetName()} unit) => this.GetHashCode() == unit.GetHashCode();";
        yield return $"\t///<inheritdoc/>";
        yield return $"\tpublic override string ToString() => $\"{{Value:0.000}} {Unit.BaseUnit.UnitSymbol}\";";

        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
        
        // yield return $"\tpublic static implicit operator";
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