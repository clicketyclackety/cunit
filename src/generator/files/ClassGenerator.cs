using System.Reflection;
using generator.units;
using generators.foundations;

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
        Lines.Clear();
        
        Lines.AddRange(GenerateNamespace());
        Lines.AddRange(GenerateClassHeader());
        Lines.AddRange(GenerateClassProperties());
        Lines.AddRange(GenerateClassConstructors());
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
        var classDeclaration = $"public readonly struct {Unit.Name} : IEquatable<{Numerics.NumberType}>";

        var iequatables = new List<string>();
        var relatedUnits = Utils.GetRelatedUnits(Unit);
        if (relatedUnits is not null && relatedUnits.Count() > 0)
            classDeclaration += ", ";
        foreach (var relatedUnit in relatedUnits)
        {
            iequatables.Add($"IEquatable<{relatedUnit.Name}>");
        }

        classDeclaration += string.Join(", ", iequatables);
        yield return classDeclaration;
        
        yield return "{";
        yield return string.Empty;
    }
    
    private IEnumerable<string> GenerateClassProperties()
    {
        // If we have multiple dimensions, this should be more complex
        if (Unit.Dimensions?.Length > 1)
        {
            var names = Generics.GetUnitParameterNames(Unit);

            yield return $"\tprivate readonly {Numerics.NumberType} _preComputedValue = 1;";
            yield return string.Empty;
            
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
                
                yield return $"\t/// <param name=\"{paramName}\">Dimension</param>";
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
    
    // Single Dimensions
    private IEnumerable<string> GenerateImplicitOperators()
    {
        yield return "\t#region Operators";
        yield return string.Empty;
        
        // Double to Type
        yield return "\t#region Casting";
        yield return string.Empty;
        
        yield return $"\t/// <summary>Converts a {Numerics.NumberType} into this Unit.</summary>";
        yield return $"\tpublic static implicit operator {Unit.Name}({Numerics.NumberType} value) => new (value);";
        yield return string.Empty;

        if (Unit.BaseUnit is not null)
        {
            yield return $"\t/// <summary>Converts {Unit.BaseUnit.Name} into this Unit.</summary>";
            yield return $"\tpublic static implicit operator {Unit.BaseUnit.Name}({Unit.Name} value) => new ({Unit.Calculation.Replace("<v>", "value.Value")});";
            yield return string.Empty;
            
            yield return $"\t/// <summary>Converts {Unit.Name} into {Unit.BaseUnit.Name}.</summary>"; // TODO : INVERT CALCULATIONS? HOW?
            yield return $"\tpublic static implicit operator {Unit.Name}({Unit.BaseUnit.Name} value) => new ({Unit.Calculation.Replace("<v>", "value.Value")});";
            yield return string.Empty;

            foreach (var baseUnit in Utils.GetRelatedUnits(Unit))
            {
                if (baseUnit == Unit.BaseUnit)
                    continue;
                
                yield return $"\t/// <summary>Converts {Unit.Name} into {baseUnit.Name}.</summary>";
                yield return
                    $"\tpublic static implicit operator {Unit.Name}({baseUnit.Name} value) => new {Unit.Name}({Calculations.GetCalcuation(Unit, baseUnit)});";
                yield return string.Empty;
            }
        }
    }

    private IEnumerable<string> GenerateTupleOperators()
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
    
    private IEnumerable<string> GeneratePlusMinusOperators()
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
            
            yield return $"\tpublic static {Unit.Name} operator {@operator}({Unit.Name} left, {Unit.Name} right)" +
                         $"=> left.Value {@operator} right.Value;";

            foreach (var relatedUnit in Utils.GetRelatedUnits(Unit))
            {   
                yield return $"\tpublic static {Unit.Name} operator {@operator}({Unit.Name} left, {relatedUnit.Name} right)" +
                             $" => left.Value {@operator} ({Unit.Name})right;";
            }
        }
    }

    private IEnumerable<string> GenerateMultiplyDivideOperators()
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
    
    private IEnumerable<string> GeneratePositiveNegativeOperators()
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
    
    private IEnumerable<string> GenerateGreaterLessThansOperators()
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
                             $" => left.Value {statement} ({Unit.Name})right;";
            }
            
            yield return string.Empty;
        }
        
        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }

    private IEnumerable<string> GenerateEquality()
    {

        yield return "\t#region Equality";
        yield return string.Empty;

        // Equality and Hashing
        yield return
            $"\t/// <summary>Compares this {Unit.Name} with a {Numerics.NumberType} for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==({Unit.Name} left, {Numerics.NumberType} right)" +
                     $" => left.Equals(right);";
        yield return
            $"\t/// <summary>Compares this {Unit.Name} with a {Numerics.NumberType} for inequality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator !=({Unit.Name} left, {Numerics.NumberType} right) => !(left == right);";
        
        yield return
            $"\t/// <summary>Compares this {Numerics.NumberType} with a {Unit.Name} for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==({Numerics.NumberType} left, {Unit.Name} right)" +
                     $" => left.Equals(right);";
        yield return
            $"\t/// <summary>Compares this {Numerics.NumberType} with a {Unit.Name} for inequality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator !=({Numerics.NumberType} left, {Unit.Name} right) => !(left == right);";
        
        yield return
            $"\t/// <summary>Compares this {Unit.Name} with a {Numerics.NumberType} for Equality (Constants Tolerance used)</summary>";
        yield return
            $"\tpublic bool Equals({Numerics.NumberType} unit) => (this.Value - unit) - cunit.Constants.Tolerance <= 0;";
        yield return string.Empty;
        
        yield return
            $"\t/// <summary>Compares this {Unit.Name} with another {Unit.Name} for equality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator ==({Unit.Name} left, {Unit.Name} right)" +
                     $" => left.Equals(right);";

        yield return
            $"\t/// <summary>Compares this {Unit.Name} with another {Unit.Name} for inequality (no tolerance used)</summary>";
        yield return $"\tpublic static bool operator !=({Unit.Name} left, {Unit.Name} right) => !(left == right);";
        
        yield return
            $"\t/// <summary>Compares this {Unit.Name} with another {Unit.Name} for Equality (Constants Tolerance used)</summary>";
        yield return
            $"\tpublic bool Equals({Unit.Name} unit) => (this - unit).Value - cunit.Constants.Tolerance <= 0;";
        yield return string.Empty;

        foreach (var relatedUnits in Utils.GetRelatedUnits(Unit))
        {
            yield return
                $"\t/// <summary>Compares this {Unit.Name} with another {relatedUnits.Name} for equality (no tolerance used)</summary>";
            yield return $"\tpublic static bool operator ==({Unit.Name} left, {relatedUnits.Name} right)" +
                         $" => left.Equals(right);";

            yield return
                $"\t/// <summary>Compares this {Unit.Name} with another {relatedUnits.Name} for inequality (no tolerance used)</summary>";
            yield return
                $"\tpublic static bool operator !=({Unit.Name} left, {relatedUnits.Name} right) => !(left == right);";
            yield return
                $"\t/// <summary>Compares this {Unit.Name} with another {relatedUnits.Name} for Equality (Constants Tolerance used)</summary>";
            yield return
                $"\tpublic bool Equals({relatedUnits.Name} unit) => (this - unit).Value - cunit.Constants.Tolerance <= 0;";
            yield return string.Empty;
        }

        yield return string.Empty;
        yield return $"\tprivate readonly int _preComputedHashCode = -1;";
        yield return $"\tpublic override int GetHashCode() => _preComputedHashCode;";
        yield return string.Empty;
        yield return $"\tpublic override bool Equals(object? obj) => obj is {Unit.Name} unit && Equals(unit);";
        yield return string.Empty;
        yield return "\tprivate readonly string _preComputedToString = \"Unset\";";
        yield return $"\tpublic override string ToString() => _preComputedToString;";

        yield return string.Empty;
        yield return "\t#endregion";

        yield return string.Empty;
        yield return "\t#endregion";
        yield return string.Empty;
    }

    private IEnumerable<string> GenerateClassFooter()
    {
        yield return "}";
        yield return string.Empty;
    }

    public IReadOnlyCollection<string> GetLines() => Lines;

    private string GetCalculation()
    {
        string formulae = Unit.Formula?.ToLowerInvariant();
        for(int i = 0; i < genericNames.Length; i++)
        {
            var genericName = genericNames[i];
            string parameterName = $"{genericName.ToUpperInvariant()}Value";
            formulae = formulae.Replace($"<{i}>", parameterName);
        }

        return formulae.ToLowerInvariant();
    }

}