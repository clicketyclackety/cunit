using System.Reflection;
using generator.units;
using generators.foundations;
using generators.units;

namespace generators.files;

public sealed class ClassGenerator
{
    private readonly List<string> Lines;
    private UnitList.UnitDescription Unit;

    private static string[] genericNames => Generics.Names;

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
    
    private IEnumerable<string> GenerateNamespace()
    {
        yield return $"namespace cunit;";
        yield return string.Empty;
    }
    
    private IEnumerable<string> GenerateClassHeader()
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
    
    private IEnumerable<string> GenerateClassProperties()
    {
        // If we have multiple dimensions, this should be more complex
        if (Unit.Dimensions?.Length > 1)
        {
            var names = Generics.GetUnitParameterNames(Unit);

            yield return $"\tprivate readonly {Numerics.NumberType} _preComputedValue = 1;";
            
            yield return "\t/// <summary>The numeric value of this unit</summary>";
            yield return $"\tpublic readonly {Numerics.NumberType} Value => _preComputedValue;";
            yield return string.Empty;
            
            foreach(var pair in Generics.GetUnitTypeParameterPairs(Unit))
            {
                yield return "\t/// <summary>The value of this unit</summary>";
                yield return $"\tprivate readonly {pair.Dim} {pair.Param} = 1;";
            }
        }
        else
        {
            yield return $"\t/// <summary>The {Numerics.NumberType} value of this unit</summary>";
            yield return $"\tpublic readonly {Numerics.NumberType} Value = 1;";
        }
        yield return string.Empty;
    }

    private IEnumerable<string> GenerateClassConstructors()
    {
        // If we have multiple dimensions, this should be more complex
        
        yield return $"\t/// <summary>Creates a new instance of a {Unit.Name}</summary>";
        if (Unit.Dimensions?.Length > 1)
        {
            string[] paramNames = Generics.GetUnitParameterNames(Unit);
            List<string> paramPair = new List<string>();
            for (int i = 0; i < Unit.Dimensions.Length; i++)
            {
                string paramName = paramNames[i].ToLowerInvariant();
                paramPair.Add($"{Numerics.NumberType} {paramName} = 1");
                
                yield return $"\t/// <param name=\"{paramName}\">{Numerics.NumberType}</param>";
            }
            yield return $"\tpublic {Unit.Name}({string.Join(", ", paramPair)})";
            yield return "\t{";
            
            foreach(var paramName in Generics.GetUnitParameterNames(Unit))
            {
                yield return $"\t\t{paramName} = {paramName.ToLowerInvariant()};";
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

    private IEnumerable<string> GenerateClassMethods()
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
    private IEnumerable<string> GenerateClassOperators()
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
            yield return $"\t/// <summary>Converts {Unit.BaseUnit.Name} into this Unit.</summary>";
            yield return $"\tpublic static implicit operator {Unit.BaseUnit.Name}({Unit.Name} value) => new {Unit.BaseUnit.Name}({Unit.Calculation.Replace("value", "value.Value")});";
            yield return string.Empty;
            
            yield return $"\t/// <summary>Converts {Unit.Name} into {Unit.BaseUnit.Name}.</summary>"; // TODO : INVERT CALCULATIONS? HOW?
            yield return $"\tpublic static implicit operator {Unit.Name}({Unit.BaseUnit.Name} value) => new {Unit.Name}({Unit.Calculation.Replace("value", "value.Value")});";
            yield return string.Empty;
        }

        // TODO : This doesn't help?
        // TODO : We want to matrix things to cast into other things!
        // TODO : Create a partial class for clarity?
        foreach (var baseUnit in GetRelatedUnits())
        {
            yield return $"\t/// <summary>Converts {Unit.Name} into {baseUnit.Name}.</summary>";
            yield return
                $"\tpublic static implicit operator {Unit.Name}({baseUnit.Name} value) => new {Unit.Name}({baseUnit.Calculation.Replace("value", "value.Value")} * {Unit.Calculation.Replace("value", "value.Value")});";
            yield return string.Empty;
        }

        // Tuple Operators
        if (Unit.Dimensions is not null)
        {
            string tuples = string.Join(", ", Unit.Dimensions);
            var parameters = string.Join(", ", genericNames[..Unit.Dimensions.Length].Select(g => $"value.{g}Value"));
            yield return $"\t/// <summary>Converts {Unit.Name} into {Unit.Name}.</summary>";
            string opString = $"\tpublic static implicit operator ({tuples}) ({Unit.Name} value) => new ({parameters});";

            yield return opString;
            yield return string.Empty;
        }

        yield return "\t#endregion";
        
        // More complexity now!
        yield return string.Empty;
        
        yield return "\t#region Mathmatic Operators";
        yield return string.Empty;
        
        
        // TODO : We should not allow / or * if there is no unit it can be muiltiplied or divided into!
        // TODO : e.g. Meter / Meter should not be allowed
        // TODO : e.g. SquareMeter * SquareMeter should not be allowed!
        
        // Maths
        string[] mathmaticOperators = new string[] { "+", "-", "/", "*" };
        
        foreach(var @operator in mathmaticOperators)
        {
            yield return string.Empty;
            yield return $"\tpublic static {Unit.Name} operator {@operator}({Unit.Name} left, {Unit.Name} right)" + 
                         $"=> left.Value {@operator} right.Value;";
            
            foreach (var relatedUnit in GetRelatedUnits())
            {
                yield return $"\tpublic static {Unit.Name} operator {@operator}({Unit.Name} left, {relatedUnit.Name} right)" +
                             $" => left.Value {@operator} ({Unit.Name})right;";
            }

            var relatedInOps = GetUnitsThatContainThisUnitInAnEquation(@operator);
            foreach (var unit in relatedInOps)
            {
                ;
                
            }

            if (@operator == "/" && Unit.Dimensions?.Length == 2)
            {
                yield return
                    $"\tpublic static {Unit.Dimensions[0]} operator {@operator}({Unit.Name} left, {Unit.Dimensions[1]} right)" +
                    $" => left.Value {@operator} right.Value;";
            }
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
            
            foreach (var relatedUnit in GetRelatedUnits())
            {
                yield return $"\tpublic static bool operator {statement}({Unit.Name} left, {relatedUnit.Name} right)" +
                          $" => left.Value {statement} ({Unit.Name})right;";
            }
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
        
        foreach (var relatedUnits in GetRelatedUnits())
        {
            yield return $"\t/// <summary>Compares this {Unit.Name} with another {relatedUnits.Name} for equality (no tolerance used)</summary>";
            yield return $"\tpublic static bool operator ==({Unit.Name} left, {relatedUnits.Name} right)" +
                         $" => left.Equals(right);";
        
            yield return $"\t/// <summary>Compares this {Unit.Name} with another {relatedUnits.Name} for inequality (no tolerance used)</summary>";
            yield return $"\tpublic static bool operator !=({Unit.Name} left, {relatedUnits.Name} right) => !(left == right);";
            yield return string.Empty;
        }
        
        yield return string.Empty;
        yield return $"\tprivate readonly int _preComputedHashCode = -1;";
        yield return $"\tpublic override int GetHashCode() => _preComputedHashCode;";
        yield return string.Empty;
        yield return $"\tpublic override bool Equals(object? obj) => obj is {Unit.Name} unit && Equals(unit);";
        yield return string.Empty;
        yield return $"\tpublic bool Equals({Unit.Name} unit) => (this.Value - unit.Value) - cunit.Constants.Tolerance <= 0;";
        yield return string.Empty;
        yield return "\tprivate readonly string _preComputedToString = \"Unset\";"; 
        yield return $"\tpublic override string ToString() => _preComputedToString;";

        yield return string.Empty;
        yield return "\t#endregion";
        
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }

    private IEnumerable<UnitList.UnitDescription> GetUnitsThatContainThisUnitInAnEquation(string @operator = null)
    {
        foreach (var unit in UnitList.GetUnits())
        {
            if (string.IsNullOrEmpty(unit.Calculation))
                continue;

            if (unit == Unit)
                continue;

            if (unit.BaseUnit != Unit || unit.BaseUnit != Unit.BaseUnit)
                continue;

            if (!string.IsNullOrEmpty(@operator) && !unit.Calculation.Contains(@operator))
                continue;
            
            yield return unit;
        }
    }

    private IEnumerable<UnitList.UnitDescription> GetRelatedUnits()
    {
        if (this.Unit.BaseUnit is null)
            yield break;
        
        foreach (var unit in UnitList.GetUnits())
        {
            if (unit.BaseUnit is null)
                continue;

            if (unit.Name == this.Unit.Name)
                continue;

            if (unit.BaseUnit != this.Unit.BaseUnit)
                continue;
            
            yield return unit;
        }
    }
    
    private IEnumerable<string> GenerateClassFooter()
    {
        yield return "}";
        yield return string.Empty;
    }

    public IReadOnlyCollection<string> GetLines() => Lines;

    private string CombineCalcuationAndDimensions()
    {
        if (Unit.Dimensions is null)
            return Unit.Calculation;
        
        string upperCalc = Unit.Calculation.ToUpperInvariant();
        for (int i = 0; i < Unit.Dimensions.Length; i++)
        {
            string upperGeneric = genericNames[i].ToUpperInvariant();
            string doubleGeneric = $"{upperGeneric}{upperGeneric}";
            upperCalc = upperCalc.Replace(doubleGeneric, Unit.Dimensions[i]);
        }

        return upperCalc;
    }

}