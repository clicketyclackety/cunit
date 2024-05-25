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
    public GUnit? BaseUnit {get;}
    public string[]? Dimensions {get;}
    public string Formula {get;}
    public string Calculation {get;}

    public double Minimum {get; set;} = double.MinValue;
    public double Maximum {get; set;} = double.MaxValue;

    public GUnit(string name,
        string symbol,
        GUnit? baseUnit = null,
        string[]? dimensions = null,
        string formula = "",
        string calculation = "",
        double min = double.MinValue,
        double max = double.MaxValue)
    {
        Name = name;
        Symbol = symbol;
        BaseUnit = baseUnit;
        Dimensions = dimensions;
        Formula = formula;
        Calculation = calculation;
        Minimum = min;
        Maximum = max;
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
        Lines.AddRange(GenerateExplicitOperators());
        Lines.AddRange(GenerateTupleOperators());
        Lines.AddRange(GeneratePlusMinusOperators());
        Lines.AddRange(GenerateMultiplyDivideOperators());
        Lines.AddRange(GeneratePositiveNegativeOperators());
        Lines.AddRange(GenerateIncrementDecrementOperators());
        Lines.AddRange(GenerateModuloOperators());
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
        yield return "using System.Numerics;";
        yield return "using cunit.Json;";
        yield return string.Empty;
        yield return "namespace cunit;";
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GenerateClassDeclaration()
    {
        yield return "/// <summary>";
        yield return $"/// Represents a {Numerics.NumberType} as a <see cref=\"{Name}\"/> Unit.";
        if (Unit.Dimensions is not null)
        {
            bool anyDifferent = new HashSet<string>(Unit.Dimensions).Count != 1;
            var diffString = anyDifferent ? "different " : "";
            yield return $"/// This unit is multi-dimensional, meaning it is constructed from multiple {diffString}units.";
        }
        yield return "/// </summary>";
        yield return $"[JsonConverter(typeof(UniversalConverter))]";
        var interfaces = new List<string>()
        {
            $"IUnit<{(Unit.BaseUnit ?? Unit).Name}>",
            "IFormattable",
            $"IEquatable<IUnit<{(Unit.BaseUnit ?? Unit).Name}>>",
            
            $"IParsable<{Unit.Name}>",
            $"IMinMaxValue<{Unit.Name}>",
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
        yield return $"\tpublic static {Unit.Name} MaxValue => new ({Unit.Maximum});";
        yield return string.Empty;
        yield return $"\tpublic static {Unit.Name} MinValue => new ({Unit.Minimum});";
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
                yield return $"\t/// <summary>The value of this <see cref=\"{pair.Dim}\"/></summary>";
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
        Func<string, string> constructorDocstring = (numeric) => $"\t/// <summary>Creates a new instance of a <see cref=\"{Unit.Name}\"/> from a <see cref=\"{numeric}\"/></summary>" + 
                                                                  "\n\t/// <remarks>Note that cunit will not prevent you using incorrect values, such as negatives or values outside of the range of possibility for a unit (e.g -400 Kelvin). Cunit will not correct your maths.</remarks>";


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
            yield return constructorDocstring($"({tupleParameters})");
            yield return $"\tpublic {Unit.Name}(({tupleParameters}) tuple) : this({tupleNames}) {{}}";
            yield return string.Empty;
                
            // SECOND CONSTRUCTORS
            foreach(var numeric in Numerics.NumberTypes)
            {
                yield return constructorDocstring(numeric);
                List<string> paramPair = new List<string>();
                for (int i = 0; i < Unit.Dimensions.Length; i++)
                {
                    string paramName = paramNames[i].ToLowerInvariant();
                    paramPair.Add($"{numeric} {paramName} = 1");
                    
                    yield return $"\t/// <param name=\"{paramName}\">Theoretical {paramName.First().ToString().ToUpper()} Dimension.</param>";
                }

                yield return $"\tpublic {Unit.Name}({string.Join(", ", paramPair)})";
                yield return "\t{";

                List<string> computedValues = new(Unit.Dimensions.Length);
                foreach(var paramName in Generics.GetUnitParameterNames(Unit))
                {
                    yield return $"\t\t{paramName} = ({Numerics.NumberType}){paramName.ToLowerInvariant()};";
                    computedValues.Add(paramName.ToLowerInvariant());
                }

                yield return $"\t\t_preComputedValue = ({Numerics.NumberType})({string.Join(" * ", computedValues)});";
                yield return $"\t\t_preComputedHash = {(Unit.BaseUnit ?? Unit).Name.GetHashCode()} ^ Value.GetHashCode();";
                yield return "\t}";
                yield return string.Empty;
            }
        }
        else
        {
            foreach(var numeric in Numerics.NumberTypes)
            {
                yield return constructorDocstring(numeric);
                yield return $"\tpublic {Unit.Name}({numeric} value = 1)";
                yield return "\t{";
                yield return $"\t\tValue = ({Numerics.NumberType})value;";
                yield return $"\t\t_preComputedHash = {Unit.Name.GetHashCode()} ^ Value.GetHashCode();";
                yield return "\t}";
                yield return string.Empty;
            }
        }
        
        yield return constructorDocstring(Numerics.NumberType);
        yield return $"\tpublic {Unit.Name}({Unit.Name} unit) : this(unit.Value) {{}}";
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GenerateClassMethods()
    {
        var baseUnit = Unit.BaseUnit ?? Unit;
        
        yield return "\t#region Methods";
        yield return string.Empty;
        yield return "\t/// <summary>Converts this unit to SI. Note that this unit may already be SI</summary>";
        if (Unit.BaseUnit is null)
            yield return $"\tpublic {baseUnit.Name} ToSI() => new (this.Value);";
        else
            yield return $"\tpublic {baseUnit.Name} ToSI() => ({baseUnit.Name})this;";
        yield return string.Empty;

        yield return $"\tpublic static {Unit.Name} Parse (string s, IFormatProvider? provider)";
        yield return "\t{";
        yield return $"\t\tif (s.Contains(Symbol)) {{}}";
        yield return $"\t\treturn new {Unit.Name}(0);";
        yield return "\t}";
        yield return string.Empty;
        yield return $"\tpublic static bool TryParse (string? s, IFormatProvider? provider, out {Unit.Name} result)";
        yield return "\t{";
        yield return $"\t\tresult = Parse(s, provider);";
        yield return $"\t\treturn result.Value != {Unit.Name}.MinValue;";
        yield return "\t}";
        yield return string.Empty;

        yield return "\t#endregion";
        yield return string.Empty;
    }
    
    // Single Dimensions
    public virtual IEnumerable<string> GenerateImplicitOperators()
    {
        
        // Double to Type
        yield return "\t#region Casting";
        yield return string.Empty;

        yield return "\t#region Implicit Operators";
        yield return string.Empty;
        
        foreach(var NumberType in Numerics.NumberTypes)
        {
            yield return $"\t/// <summary>Converts a <see cref=\"{NumberType}\"/> into this <see cref=\"{Unit.Name}\"/>.</summary>";
            yield return $"\tpublic static implicit operator {Unit.Name}({NumberType} value) => new (value);";
            yield return string.Empty;
        }

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

        yield return "\t#endregion";
        yield return string.Empty;
    }
    
    // Single Dimensions
    public virtual IEnumerable<string> GenerateExplicitOperators()
    {
        yield return "\t#region Explicit Operators";
        yield return string.Empty;
        
        foreach(var NumberType in Numerics.NumberTypes)
        {
            yield return $"\t/// <summary>Converts a this <see cref=\"{Unit.Name}\"/> into <see cref=\"{NumberType}\"/>.</summary>";
            yield return $"\tpublic static explicit operator {NumberType}({Unit.Name} unit) => ({NumberType})unit.Value;";
            yield return string.Empty;
        }

        yield return "\t#endregion";
        yield return string.Empty;
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
        
        // More complexity now!
        yield return string.Empty;
    }
    
    // TODO : Should a multi-dimensional unit be allowed to "add" 1?
    public virtual IEnumerable<string> GeneratePlusMinusOperators()
    {
        yield return "\t#region Mathmatic Operators";
        
        // + and -
        foreach(var @operator in new [] { "+", "-"})
        {
            foreach(var numberType in Numerics.NumberTypes)
            {
                yield return string.Empty;

                yield return $"\tpublic static {Unit.Name} operator {@operator}({Unit.Name} left, {numberType} right)" +
                            $"=> left.Value {@operator} ({Numerics.NumberType})right;";
                yield return $"\tpublic static {Unit.Name} operator {@operator}({numberType} left, {Unit.Name} right)" +
                            $"=> ({Numerics.NumberType})left {@operator} right.Value;";
            }

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
                        yield return $"\t\tvar {g} = left.{gv} {@operator} ({Numerics.NumberType})right.{gv};";
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
        
        foreach(var op in new[] { "/", "*" })
        {
            foreach(var numberType in Numerics.NumberTypes)
            {
                yield return $"\tpublic static {Unit.Name} operator {op}({Unit.Name} left, {numberType} right)" +
                            $"=> left.Value {op} ({Numerics.NumberType})right;";
                yield return $"\tpublic static {Unit.Name} operator {op}({numberType} left, {Unit.Name} right)" +
                            $"=> ({Numerics.NumberType})left {op} right.Value;";
            }

            yield return string.Empty;
        }

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
        
        var setPairs = Utils.GetBuildingSets(Unit);
        foreach (var setPair in setPairs)
        {
            if (setPair.Count < 2)
                continue;

            var leftUnit = setPair[1].Name;
            var rightUnit = setPair[2].Name;

            if (leftUnit != Unit.Name && rightUnit != Unit.Name) continue;

            yield return
                $"\tpublic static {setPair[0].Name} operator *({leftUnit} left, {rightUnit} right)" +
                $" => left.Value / right.Value;";
        }

        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }
    
    public virtual IEnumerable<string> GenerateIncrementDecrementOperators()
    {   
        if (Unit.Dimensions is null)
        {

            yield return "\t#region Increment Decrement";
            yield return string.Empty;

            yield return $"\tpublic static {Unit.Name} operator ++({Unit.Name} unit) => new (unit.Value + 1);";
            yield return string.Empty;
            yield return $"\tpublic static {Unit.Name} operator --({Unit.Name} unit) => new (unit.Value - 1);";
            
            yield return string.Empty;
            yield return "\t#endregion";
            yield return string.Empty;

        }
    }
    
    public virtual IEnumerable<string> GenerateModuloOperators()
    { 
        yield return "\t#region Modulo";
        yield return string.Empty;
        
        foreach(var numberType in Numerics.NumberTypes)
        {
            yield return $"\tpublic static {Unit.Name} operator %({Unit.Name} left, {numberType} right)" +
                        $"=> left.Value % ({Numerics.NumberType})right;";
            yield return $"\tpublic static {Unit.Name} operator %({numberType} left, {Unit.Name} right)" +
                        $"=> ({Numerics.NumberType})left % right.Value;";
        }
     
        var unitPairs = Utils.GetBuildPieces(Unit);   
        foreach (var unitPair in unitPairs)
        {
            if (unitPair.Count < 2)
                continue;
            
            yield return
                $"\tpublic static {unitPair[0].Name} operator %({Unit.Name} left, {unitPair[1].Name} right)" +
                $" => left.Value % right.Value;";

            if (unitPair[0] == unitPair[1])
                continue;
            
            yield return
                $"\tpublic static {unitPair[1].Name} operator %({Unit.Name} left, {unitPair[0].Name} right)" +
                $" => left.Value % right.Value;";
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
            foreach(var numberType in Numerics.NumberTypes)
            {
                yield return $"\tpublic static bool operator {statement}({Unit.Name} left, {numberType} right)" +
                            $" => left.Value {statement} ({Numerics.NumberType})right;";
                yield return $"\tpublic static bool operator {statement}({numberType} left, {Unit.Name} right)" +
                            $" => ({Numerics.NumberType})left {statement} right.Value;";    
            }

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
        
        foreach(var numberType in Numerics.NumberTypes)
        {
            yield return
                $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with a <see cref=\"{numberType}\"/> for equality (Constants Tolerance used)</summary>";
            yield return
                $"\tpublic bool Equals({numberType} value) => Math.Abs(({numberType})this.Value - value) <= ({numberType})cunit.Constants.Tolerance;";
            yield return
                $"\t/// <summary>Compares IUnit<{unitOrBaseUnit}> with a <see cref=\"{numberType}\"/> for equality given a tolerance</summary>";
            yield return
                $"\tpublic bool EpsilonEquals({numberType} value, {numberType} tolerance) => (Math.Abs(({numberType})this.Value - value)) <= tolerance;";
            yield return string.Empty;

            yield return
                $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with a <see cref=\"{numberType}\"/> for equality (no tolerance used)</summary>";
            yield return $"\tpublic static bool operator ==({Unit.Name} left, {numberType} right)" +
                        $" => ({numberType})left.Value == right;";

            yield return
                $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with a <see cref=\"{numberType}\"/> for inequality (no tolerance used)</summary>";
            yield return
                $"\tpublic static bool operator !=({Unit.Name} left, {numberType} right) => !(({numberType})left.Value == right);";
            yield return string.Empty;
        }

        yield return
            $"\t/// <summary>Compares this <see cref=\"{Unit.Name}\"/> with another <see cref=\"{Unit.Name}\"/> for equality (Constants Tolerance used)</summary>";
        yield return
            $"\tpublic bool Equals(IUnit<{unitOrBaseUnit}>? unit) => unit is not null && Math.Abs((this.ToSI() - unit.ToSI()).Value) <= cunit.Constants.Tolerance;";
        yield return
            $"\t/// <summary>Compares IUnit<{unitOrBaseUnit}> with <see cref=\"{Unit.Name}\"/> for equality given a tolerance</summary>";
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