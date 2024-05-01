using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using generator.files;
using generator.units;
using generators.foundations;

namespace generators.files;

internal class ExtensionUnit : GUnit
{
    internal record struct Extension(string Name, double Multiplier, string Symbol);

    internal static UnitRange None => new(0, 0);

    internal static UnitRange All => new(-1, 1E100);
    internal static UnitRange Tiny => new(-1, 1E-100);
    internal static UnitRange Big => new(1, 1E100);

    public double Multiplier { get; }

    internal ExtensionUnit(string name, double multipler, string symbol) 
        : base(name, symbol, calculation:$"<vV> * {multipler}")
    {
        Multiplier = multipler;
    }

    public override List<string> Generate()
    {
        Lines.Clear();
        Lines.AddRange(GenerateNamespace());
        Lines.AddRange(GenerateClassDeclaration());
        Lines.AddRange(GenerateClassProperties());
        Lines.AddRange(GenerateConstructors());
        
        int before = Lines.Count;
        
        // Lines.AddRange(GenerateClassMethods());
        Lines.AddRange(GenerateImplicitOperators());
        Lines.AddRange(GenerateTupleOperators());
        // Lines.AddRange(GeneratePlusMinusOperators());
        Lines.AddRange(GenerateMultiplyDivideOperators());
        Lines.AddRange(GeneratePositiveNegativeOperators());
        Lines.AddRange(GenerateGreaterLessThansOperators());
        Lines.AddRange(GenerateEquality());
        // Lines.AddRange(GenerateClassFooter());
        int max = Lines.Count;
        Lines.AddRange(GenerateExtensions());

        for(int i = before; i < max; i++)
        {
            Lines[i] = Lines[i].Replace(Name, $"{Name}<TUnit>");
        }

        return Lines;
    }

    public override IEnumerable<string> GenerateClassDeclaration()
    {
        yield return "/// <summary>";
        yield return $"/// Represents a {Name} Unit.";
        yield return "/// </summary>";
        // yield return $"[JsonConverter(typeof({Name}JsonConverter))]";
        yield return $"public readonly struct {Name}<TUnit> : IUnit<TUnit>";
        yield return "{";
        yield return string.Empty;
        yield return $"\tpublic {Name}(double value, Func<double, TUnit> construct, string unitSymbol)";
        yield return "\t{";
        yield return "\t\tValue = value;";
        yield return "\t\tConstruct = construct;";
        yield return "\t\tUnitString = unitSymbol;";
        yield return "\t}";
        yield return string.Empty;
        yield return $"\tpublic {Name}(IUnit unit, Func<double, TUnit> construct, string unitSymbol)";
        yield return "\t{";
        yield return $"\t\tValue = unit.Value;"; // / {extension.Multiplier};";
        yield return "\t\tConstruct = construct;";
        yield return "\t\tUnitString = unitSymbol;";
        yield return "\t}";
        yield return string.Empty;
        yield return $"\tprivate Func<double, TUnit> Construct {{ get; }}";
        yield return string.Empty;
        yield return "\tprivate string UnitString { get; }";
    }

    public override IEnumerable<string> GenerateEquality()
    {
            yield return $"\tpublic TUnit ToSI() => Construct(Value * {Multiplier});";
            yield return string.Empty;
            yield return $"\tpublic override string ToString() => ToString(\"G\");";
            yield return "\tpublic string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);";
            yield return "\tpublic string ToString(string? format, IFormatProvider? formatProvider)";
            yield return "\t\t=> formatProvider switch {";
            yield return
                $"\t\t\t_ => $\"{{Value.ToString(format ?? \"G\", formatProvider ?? CultureInfo.CurrentCulture)}} {Symbol}{{UnitString}}\",";
            yield return "\t\t};";
            yield return string.Empty;
            yield return "}";
    }

    private IEnumerable<string> GenerateExtensions()
    {
        yield return string.Empty;

        yield return $"public partial class {Name}";
        yield return "{";
        
        yield return string.Empty;
        
        // TODO : Put each type of unit in it's own Namepsace!
        // TODO : Reverse this?
        // TODO : Exclude unecessary units! a Millibyte is stupid!
        foreach(var unit in UnitList.GetUnits())
        {
            if (unit.Dimensions?.Length > 1) continue;
            if (unit.ValidExtensions.Start == unit.ValidExtensions.End) continue;
            if (!unit.ValidExtensions.Inside(Multiplier)) continue;

            yield return $"\tpublic static {Name}<{unit.Name}> {unit.Name}({@unit.Name} @{unit.Name.ToLowerInvariant()}) => new(@{unit.Name.ToLowerInvariant()}, (num) => new (num), \"{unit.Symbol}\");";
        }

        yield return "}";

        /*

        // TODO : Generate This
        public static class Milli
        {
            public static Milli<Gram> Gram(Gram gram) => new(gram);
        }
        */

        /*
        foreach(var extension in extensions)
        {
            yield return string.Empty;
            yield return $"public readonly struct {extension.Name}<TUnit> : IUnit<TUnit>";
            yield return "{";
            yield return "\tpublic double Value { get; }";
            yield return string.Empty;
            yield return $"\tprivate Func<double, TUnit> Construct {{ get; }}";
            yield return string.Empty;
            yield return "\tprivate string UnitString { get; }";
            yield return string.Empty;
            yield return $"\tpublic {extension.Name}(double value, Func<double, TUnit> construct, string unitSymbol)";
            yield return "\t{";
            yield return "\t\tValue = value;";
            yield return "\t\tConstruct = construct;";
            yield return "\t\tUnitString = unitSymbol;";
            yield return "\t}";
            yield return string.Empty;
            yield return $"\tpublic {extension.Name}(IUnit unit, Func<double, TUnit> construct, string unitSymbol)";
            yield return "\t{";
            yield return $"\t\tValue = unit.Value;"; // / {extension.Multiplier};";
            yield return "\t\tConstruct = construct;";
            yield return "\t\tUnitString = unitSymbol;";
            yield return "\t}";
            yield return string.Empty;
            // yield return $"\tpublic static {extension.Key}<Gram> Gram(Gram gram) => new Milli(gram.Value / 1000);";
            // yield return string.Empty;
            yield return $"\tpublic TUnit ToSI() => Construct(Value * {extension.Multiplier});";
            yield return string.Empty;
            yield return $"\tpublic override string ToString() => ToString(\"G\");";
            yield return "\tpublic string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);";
            yield return "\tpublic string ToString(string? format, IFormatProvider? formatProvider)";
            yield return "\t\t=> formatProvider switch {";
            yield return
                $"\t\t\t_ => $\"{{Value.ToString(format ?? \"G\", formatProvider ?? CultureInfo.CurrentCulture)}} {extension.Symbol}{{UnitString}}\",";
            yield return "\t\t};";
            yield return string.Empty;
            yield return "}";
        }
        */
    }

    public string GetFilePath()
        => Path.Combine(FileUtils.GetCunitBaseDirectory(), "Extensions.cs");
        
}