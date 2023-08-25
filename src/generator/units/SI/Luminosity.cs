using generators;
using generators.units;

namespace generator.units.si;

public sealed class Luminosity : GeneratableUnit
{
    public Luminosity()
    {
        Name = nameof(Luminosity);
        DefaultValue = "1";
        UnitSymbol = "cd";
        Type = UnitType.Luminosity;
        CompatibleDimensions = new UnitType[][]
        {
            new []  { UnitType.Luminosity },
        };
    }
}