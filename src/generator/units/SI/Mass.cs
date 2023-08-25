using generators;
using generators.units;

namespace generator.units.si;

public sealed class Kilogram : GeneratableUnit
{
    public Kilogram()
    {
        Name = nameof(Kilogram);
        DefaultValue = "1";
        UnitSymbol = "Kg";
        Type = UnitType.Mass;
        CompatibleDimensions = new UnitType[][]
        {
            new []  { UnitType.Mass },
        };
    }
}