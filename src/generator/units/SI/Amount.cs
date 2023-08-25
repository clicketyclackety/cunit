using generators;
using generators.units;

namespace generator.units.si;

public sealed class Amount : GeneratableUnit
{
    public Amount()
    {
        Name = nameof(Amount);
        DefaultValue = "1";
        UnitSymbol = "Mole";
        Type = UnitType.Amount;
        CompatibleDimensions = new UnitType[][]
        {
            new []  { UnitType.Amount },
        };
    }
}