using System.Reflection;
using generators.files;
using generators.foundations;

namespace generator.units;

public class GUnit : IGenerateableFile
{
    
    protected List<string> Lines { get; } = new();

    public string Name {get;}
    public string Symbol {get;}
    public GUnit Unit => this;
    public GUnit BaseUnit {get;}
    public string[] Dimensions {get;}
    public string Formula {get;}
    public string Calculation {get;}

    public GUnit(string name,
        string symbol,
        GUnit? baseUnit = null,
        string[]? dimensions = null,
        string formula = "",
        string calculation = "")
    {
        Name = name;
        Symbol = symbol;
        BaseUnit = baseUnit;
        Dimensions = dimensions;
        Formula = formula;
        Calculation = calculation;
    }

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
        Lines.AddRange(GenerateTupleOperators());
        Lines.AddRange(GeneratePlusMinusOperators());
        Lines.AddRange(GenerateMultiplyDivideOperators());
        Lines.AddRange(GeneratePositiveNegativeOperators());
        Lines.AddRange(GenerateGreaterLessThansOperators());
        Lines.AddRange(GenerateEquality());
        Lines.AddRange(GenerateClassFooter());
        Lines.Add(string.Empty);

        return Lines;
    }

    private IEnumerable<string> GenerateClassConstants()
    {
        yield return $"\t/// <summary>The symbol of this <see cref=\"{Unit.Name}\"></summary>";
        yield return $"\tpublic const string Symbol = \"{Unit.Symbol}\";";
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
        
        return Path.Combine(srcDir, "cunit", $"{Unit.Name}.cs");
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
        yield return $"/// Represents a <see cref=\"{Name}\"/> Unit.";
        yield return "/// </summary>";
        yield return $"[JsonConverter(typeof(UniversalConverter))]";
        var interfaces = new List<string>()
        {
            $"IUnit<{(Unit.BaseUnit ?? Unit).Name}>",
            "IFormattable",
            $"IEquatable<IUnit<{(Unit.BaseUnit ?? Unit).Name}>>",
        };

        if (Unit.Dimensions is not null)
        {
            interfaces.Add($"IUnit<{string.Join(", ", Unit.Dimensions)}>");
        }

        var classDeclaration = $"public readonly struct {Unit.Name} :\n\t\t\t\t";
        
        var relatedUnits = Utils.GetRelatedUnits(this).Union(new [] {Unit});
        foreach (var relatedUnit in relatedUnits)
        {
            interfaces.Add($"IEquatable<{relatedUnit.Name}>");
        }

        classDeclaration += string.Join(",\n\t\t\t\t", interfaces);
        yield return classDeclaration;
        
        yield return "{";
        yield return string.Empty;
    }

    public virtual IEnumerable<string> GenerateClassProperties()
    {
        yield return $"\tprivate readonly int _preComputedHash = -1;";
        yield return string.Empty;
        
        // If we have multiple dimensions, this should be more complex
        if (Unit.Dimensions?.Length > 1)
        {
            var names = Generics.GetUnitParameterNames(this);

            yield return $"\tprivate readonly {Numerics.NumberType} _preComputedValue = 1;";
            
            yield return string.Empty;
            
            yield return $"\t/// <summary>The numeric value of this <see cref=\"{Unit.Name}\"/></summary>";
            yield return $"\tpublic readonly {Numerics.NumberType} Value => _preComputedValue;";
            yield return string.Empty;
            
            foreach(var pair in Generics.GetUnitTypeParameterPairs(this))
            {
                yield return $"\t/// <summary>The value of this <see cref=\"{Unit.Name}\"/></summary>";
                yield return $"\tpublic {pair.Dim} {pair.Param} {{ get; }} = 1;";
            }
        }
        else
        {
            yield return $"\t/// <summary>The <see cref=\"{Numerics.NumberType}\"/> value of this unit</summary>";
            yield return $"\tpublic {Numerics.NumberType} Value {{ get; }} = 1;";
        }
        
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GenerateConstructors()
    {
        yield return $"\t/// <summary>Creates a new instance of a <see cref=\"{Unit.Name}\"/></summary>";
        if (Unit.Dimensions?.Length > 1)
        {
            string[] paramNames = Generics.GetUnitParameterNames(this);
            
            string tuples = string.Join(", ", Unit.Dimensions);
            List<(string, string)> tupleValues = new();
            for (int i = 0; i < Unit.Dimensions.Length; i++)
            {
                tupleValues.Add(($"{Unit.Dimensions[i]}", $"{Generics.Names[i].ToLowerInvariant()}"));
            }
            var tupleParameters = string.Join(", ", tupleValues.Select(tv => $"{tv.Item1} {tv.Item2}"));
            var tupleNames = string.Join(", ", tupleValues.Select(tv => $"tuple.{tv.Item2}.Value"));
            
            // TUPLE CONSTRUCTOR
            yield return $"\tpublic {Unit.Name}(({tupleParameters}) tuple)";
            yield return $"\t\t: this({tupleNames})";
            yield return "\t{ }";
            yield return string.Empty;
            
            yield return $"\t/// <summary>Creates a new instance of a <see cref=\"{Unit.Name}\"/></summary>";
            
            // SECOND CONSTRUCTOR
            List<string> paramPair = new List<string>();
            for (int i = 0; i < Unit.Dimensions.Length; i++)
            {
                string paramName = paramNames[i].ToLowerInvariant();
                paramPair.Add($"{Numerics.NumberType} {paramName} = 1");
                
                yield return $"\t/// <param name=\"{paramName}\">Dimension</param>";
            }
            yield return $"\tpublic {Unit.Name}({string.Join(", ", paramPair)})";
            yield return "\t{";

            List<string> computedValues = new(Unit.Dimensions.Length);
            foreach(var paramName in Generics.GetUnitParameterNames(Unit))
            {
                yield return $"\t\t{paramName} = {paramName.ToLowerInvariant()};";
                computedValues.Add(paramName.ToLowerInvariant());
            }

            yield return $"\t\t_preComputedValue = {string.Join(" * ", computedValues)};";
            yield return $"\t\t_preComputedHash = {(Unit.BaseUnit ?? Unit).Name.GetHashCode()} ^ Value.GetHashCode();";
        }
        else
        {
            yield return $"\tpublic {Unit.Name}({Numerics.NumberType} value = 1)";
            yield return "\t{";
            yield return "\t\tValue = value;";
            yield return $"\t\t_preComputedHash = {Unit.Name.GetHashCode()} ^ Value.GetHashCode();";
        }
        
        yield return "\t}";
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GenerateClassMethods()
    {
        var baseUnit = Unit.BaseUnit ?? Unit;
        
        yield return "\t#region Methods";
        yield return string.Empty;
        yield return "\t/// <summary>Converts this unit to SI. Note that this unit may already be SI</summary>";
        yield return $"\tpublic {baseUnit.Name} ToSI() => ({baseUnit.Name})this;";
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }
    
    // Single Dimensions
    public virtual IEnumerable<string> GenerateImplicitOperators()
    {
        yield return "\t#region Operators";
        yield return string.Empty;
        
        // Double to Type
        yield return "\t#region Casting";
        yield return string.Empty;
        
        yield return $"\t/// <summary>Converts a <see cref=\"{Numerics.NumberType}\"/> into this <see cref=\"{Unit.Name}\"/>.</summary>";
        yield return $"\tpublic static implicit operator {Unit.Name}({Numerics.NumberType} value) => new (value);";
        yield return string.Empty;

        if (Unit.BaseUnit is not null)
        {
            yield return $"\t/// <summary>Converts <see cref=\"{Unit.BaseUnit.Name}\"/> into this <see cref=\"{Unit.Name}\"/>.</summary>";
            yield return $"\tpublic static implicit operator {Unit.BaseUnit.Name}({Unit.Name} value) => new (({Calculations.FormatCalculation(Unit.Calculation)}));";
            yield return string.Empty;
            
            yield return $"\t/// <summary>Converts <see cref=\"{Unit.Name}\"/> into <see cref=\"{Unit.BaseUnit.Name}\"/>.</summary>";
            yield return $"\tpublic static implicit operator {Unit.Name}({Unit.BaseUnit.Name} value) => new (({Calculations.InvertCalculation(Calculations.FormatCalculation(Unit.Calculation))}));";
            yield return string.Empty;

            foreach (var r in Utils.GetRelatedUnits(this))
            {
                if (r == Unit.BaseUnit)
                    continue;
                
                yield return $"\t/// <summary>Converts <see cref=\"{Unit.Name}\"/> into {r.Name}.</summary>";
                yield return
                    $"\tpublic static implicit operator {Unit.Name}({r.Name} value) => value.ToSI();";
                yield return string.Empty;
            }
        }
    }

    public virtual IEnumerable<string> GenerateTupleOperators()
    {
        // Tuple Operators
        if (Unit.Dimensions is not null)
        {
            string tuples = string.Join(", ", Unit.Dimensions);
            var parameters = string.Join(", ", Generics.GetUnitNames(Unit).Select(g => $"value.{g}Value"));
            yield return $"\t/// <summary>Converts {Unit.Name} into {Unit.Name}.</summary>";
            string opString = $"\tpublic static implicit operator ({tuples}) ({Unit.Name} value) => new ({parameters});";

            yield return opString;
            yield return string.Empty;
        }

        yield return "\t#endregion";
        
        // More complexity now!
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GeneratePlusMinusOperators()
    {
        yield return "\t#region Mathmatic Operators";
        
        // + and -
        foreach(var @operator in new [] { "+", "-"})
        {
            yield return string.Empty;

            yield return $"\tpublic static {Unit.Name} operator {@operator}({Unit.Name} left, {Numerics.NumberType} right)" +
                         $"=> left.Value {@operator} right;";
            yield return $"\tpublic static {Unit.Name} operator {@operator}({Numerics.NumberType} left, {Unit.Name} right)" +
                         $"=> left {@operator} right.Value;";

            foreach (var relatedUnit in new []{ Unit }.Union(Utils.GetRelatedUnits(Unit)))
            {
                string declarationLine =
                    $"\tpublic static {Unit.Name} operator {@operator}({Unit.Name} left, {relatedUnit.Name} right)";
                if (Unit.Dimensions?.Length > 1)
                {
                    yield return declarationLine;
                    yield return "\t{";
                    string operations = string.Empty;
                    List<string> genericNames = new(Unit.Dimensions.Length);
                    for (int i = 0; i < Unit.Dimensions.Length; i++)
                    {
                        var g = Generics.Names[i].ToLowerInvariant();
                        genericNames.Add($"{g}.Value");
                        var gv = Generics.GetParam(i);
                        yield return $"\t\tvar {g} = left.{gv} {@operator} right.{gv};";
                    }
                    
                    yield return $"\t\treturn new ({string.Join(", ", genericNames)});";
                    yield return "\t}";
                }
                else
                {
                    declarationLine += $" => left.ToSI().Value {@operator} right.ToSI().Value;";
                    yield return declarationLine;
                }
            }
        }
    }

    public virtual IEnumerable<string> GenerateMultiplyDivideOperators()
    {
        yield return string.Empty;
        
        yield return $"\tpublic static {Unit.Name} operator /({Unit.Name} left, {Numerics.NumberType} right)" +
                     $"=> left.Value / right;";
        yield return $"\tpublic static {Unit.Name} operator /({Numerics.NumberType} left, {Unit.Name} right)" +
                     $"=> left / right.Value;";
     
        var unitPairs = Utils.GetBuildPieces(Unit);   
        foreach (var unitPair in unitPairs)
        {
            if (unitPair.Count < 2)
                continue;
            
            yield return
                $"\tpublic static {unitPair[0].Name} operator /({Unit.Name} left, {unitPair[1].Name} right)" +
                $" => left.Value / right.Value;";

            if (unitPair[0] == unitPair[1])
                continue;
            
            yield return
                $"\tpublic static {unitPair[1].Name} operator /({Unit.Name} left, {unitPair[0].Name} right)" +
                $" => left.Value / right.Value;";
        }
        
        yield return string.Empty;
        yield return $"\tpublic static {Unit.Name} operator *({Unit.Name} left, {Numerics.NumberType} right)" +
                     $"=> left.Value * right;";
        yield return $"\tpublic static {Unit.Name} operator *({Numerics.NumberType} left, {Unit.Name} right)" +
                     $"=> left * right.Value;";
        
        var setPairs = Utils.GetBuildingSets(Unit);
        foreach (var setPair in setPairs)
        {
            if (setPair.Count < 2)
                continue;

            yield return
                $"\tpublic static {setPair[0].Name} operator *({setPair[1].Name} left, {setPair[2].Name} right)" +
                $" => left.Value / right.Value;";
        }

        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GeneratePositiveNegativeOperators()
    {
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
    }
    
    public virtual IEnumerable<string> GenerateGreaterLessThansOperators()
    {
        yield return "\t#region Greater/Less";
        yield return string.Empty;
        
        // Greater, Less Than etc.
        foreach (var statement in Numerics.ComparisonOperators)
        {
            yield return $"\tpublic static bool operator {statement}({Unit.Name} left, {Numerics.NumberType} right)" +
                         $" => left.Value {statement} right;";
            yield return $"\tpublic static bool operator {statement}({Numerics.NumberType} left, {Unit.Name} right)" +
                         $" => left {statement} right.Value;";
            yield return $"\tpublic static bool operator {statement}({Unit.Name} left, {Unit.Name} right)" +
                         $" => left.Value {statement} right.Value;";
            
            foreach (var relatedUnit in Utils.GetRelatedUnits(Unit))
            {
                yield return $"\tpublic static bool operator {statement}({Unit.Name} left, {relatedUnit.Name} right)" +
                             $" => left.ToSI().Value {statement} right.ToSI().Value;";
            }
            
            yield return string.Empty;
        }
        
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }

    public virtual IEnumerable<string> GenerateEquality()
    {
        yield return "\t#region Equality";
        yield return string.Empty;

        // Equality and Hashing
        
        string unitOrBaseUnit = (Unit.BaseUnit ?? Unit).Name;
        
        yield return
            $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with another <see cref=\"{Unit.Name}\"/> for Equality (Constants Tolerance used)</summary>";
        yield return
            $"\tpublic bool Equals(IUnit<{unitOrBaseUnit}>? unit) => unit is not null && Math.Abs((this.ToSI() - unit.ToSI()).Value) <= cunit.Constants.Tolerance;";
        yield return
            $"\t/// <summary>Compares IUnit<{unitOrBaseUnit}> with <see cref=\"{Unit.Name}\"/> for Equality given a tolerance</summary>";
        yield return
            $"\tpublic bool EpsilonEquals(IUnit<{unitOrBaseUnit}> unit, double tolerance) => Math.Abs((this.ToSI() - unit.ToSI()).Value) <= tolerance;";
    
        yield return
            $"\t/// <summary>Compares an object with another <see cref=\"{Unit.Name}\"/> for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==(IUnit<{unitOrBaseUnit}> left, {Unit.Name} right)" +
                     $" => left.Equals(right);";
        yield return
            $"\t/// <summary>Compares this {Unit.Name} with another {Unit.Name} for inequality (no tolerance used)</summary>";
        yield return
            $"\tpublic static bool operator !=(object left, {Unit.Name} right) => !(left == right);";

        yield return
            $"\t/// <summary>Compares an object with another <see cref=\"{Unit.Name}\"/> for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==(object left, {Unit.Name} right)" +
                     $" => left is IUnit<{unitOrBaseUnit}> unit && unit.Equals(right);";
        yield return
            $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with another <see cref=\"{Unit.Name}\"/> for inequality (no tolerance used)</summary>";
        yield return
            $"\tpublic static bool operator !=(IUnit<{unitOrBaseUnit}> left, {Unit.Name} right) => !(left == right);";

        yield return string.Empty;

        foreach (var relatedUnit in Utils.GetRelatedUnits(Unit).Union(new []{ Unit }))
        {
            yield return
                $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with another <see cref=\"{relatedUnit.Name}\"/> for equality (no tolerance used)</summary>";
            yield return $"\tpublic static bool operator ==({Unit.Name} left, {relatedUnit.Name} right)" +
                         $" => left.Equals(right);";

            yield return $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with another <see cref=\"{relatedUnit.Name}\"/> for inequality (no tolerance used)</summary>";
            yield return $"\tpublic static bool operator !=({Unit.Name} left, {relatedUnit.Name} right) => !(left == right);";

            var calc = Unit.BaseUnit is null ? "this - unit" : "unit - this";
            yield return $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with another <see cref=\"{relatedUnit.Name}\"/> for Equality (Constants Tolerance used)</summary>";
            yield return $"\tpublic bool Equals({relatedUnit.Name} unit) => Math.Abs(({calc}).Value) <= cunit.Constants.Tolerance;";
            yield return $"\t/// <summary>Compares <see cref=\"{Unit.Name}\"/> with {relatedUnit.Name} for Equality given a tolerance</summary>";
            yield return $"\tpublic bool EpsilonEquals({relatedUnit.Name} unit, double tolerance) => Math.Abs(({calc}).Value) <= tolerance;";
            
            yield return string.Empty;
        }

        yield return string.Empty;
        yield return $"\tpublic override int GetHashCode() => _preComputedHash;";
        yield return string.Empty;

        yield return $"\tpublic override bool Equals(object? obj) => obj is IUnit<{unitOrBaseUnit}> unit && Equals(unit);";
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