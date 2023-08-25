using generators;
using generators.units;

namespace generator.units.si;

public sealed class Time : GeneratableUnit
{
    public Time()
    {
        Name = nameof(Time);
        DefaultValue = "1";
        UnitSymbol = "s";
        Type = UnitType.Time;
        CompatibleDimensions = new UnitType[][]
        {
            new [] { UnitType.Time }
        };
    }
}