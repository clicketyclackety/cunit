using generators;
using generators.units;

namespace generator.units.si;

public sealed class ElectricCurrent : GeneratableUnit
{

    public ElectricCurrent()
    {
        Name = nameof(ElectricCurrent);
        DefaultValue = "1";
        UnitSymbol = "Amp";
        Type = UnitType.ElectricCurrent;
        CompatibleDimensions = new UnitType[][]
        {
            new []  { UnitType.ElectricCurrent },
        };
    }
    
}