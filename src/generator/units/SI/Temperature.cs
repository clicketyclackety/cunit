using generators;
using generators.units;

namespace generator.units.si;

public sealed class Temperature : GeneratableUnit
{
    public Temperature()
    {
        Name = nameof(Temperature);
        DefaultValue = "1";
        UnitSymbol = "K";
        Type = UnitType.Temperature;
        CompatibleDimensions = new UnitType[][]
        {
            new [] { UnitType.Temperature }
        };
    }
}