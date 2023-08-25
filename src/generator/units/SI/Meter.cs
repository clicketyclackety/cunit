using generator.units.constants;
using generators;
using generators.units;
using generators.utils;

namespace generator.units.si;


public sealed class Meter : GeneratableUnit
{

    protected override IEnumerable<string> GenerateClassProperties()
    {
        for (int d = 0; d < this.CompatibleDimensions.Length; d++)
        {
            yield return $"\tinternal readonly {ValueType} _value;";
            yield return string.Empty;
        }
    }

    protected override IEnumerable<string> GenerateClassOperators()
    {
        // Double to Type
        yield return $"\tpublic static implicit operator {Name}({ValueType} value) => new(value);";
        yield return string.Empty;

        var consts = Utils.GetConstants(typeof(BaseTenPrefixes));
        string meter = nameof(Meter).ToLowerInvariant();
        foreach (var _const in consts)
        {
            string multiplier = _const.GetValue(null).ToString();
        
            // yield return $"\tpublic static implicit operator {_const.Name}{meter}({this.Name} value) => new (value._value / {multiplier});";
            yield return $"\tpublic static implicit operator {this.Name}({_const.Name}{meter} value) => new (value._value * {multiplier});";   
        }
    }

    public Meter()
    {
        Name = nameof(Meter);
        DefaultValue = "1";
        UnitSymbol = "M";
        Type = UnitType.Length;
        CompatibleDimensions = new UnitType[][]
        {
            new []  { UnitType.Length },
            new []  { UnitType.Length, UnitType.Length },
            new []  { UnitType.Length, UnitType.Length, UnitType.Length },
            new []  { UnitType.Length, UnitType.Length, UnitType.Length, UnitType.Mass },
        };
    }
}