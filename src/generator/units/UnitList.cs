using generators;
using generators.files;

namespace generator.units;

public static class UnitList
{
    public record UnitDescription(string Name,
                                        string Symbol,
                                        UnitDescription? BaseUnit = null,
                                        string[]? Dimensions = null,
                                        string? Formula = "",
                                        double Ratio = 1);

    private static IEnumerable<UnitDescription> units;

    public static IEnumerable<UnitDescription> GetUnits()
    {
        if (units is null)
            units = getUnits();

        return units;
    }

    private static IEnumerable<UnitDescription> getUnits()
    {
        // what is it
        // What is it made of
        // How does it relate to an SI unit?
        var meter = new UnitDescription("Meter", "m");
        var millimeter = new UnitDescription("Millimeter", "mm", meter, Ratio:0.001);
        UnitDescription[] distanceUnits = new []
        {
            meter,
            millimeter
        };

        UnitDescription? meterSquared = null;
        UnitDescription? meterCubed = null;
        foreach (var unit in distanceUnits)
        {
            var squared = new UnitDescription($"{unit.Name}Squared", "m²", meterSquared, new [] {unit.Name, unit.Name}, "xx * yy"); 
            var cubed = new UnitDescription($"{unit.Name}Squared", "m³", meterCubed, new [] {unit.Name, unit.Name, unit.Name }, "xx * yy * zz");
            
            if (unit.Name.Equals(meter.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                meterSquared = squared;
                meterCubed = cubed;
            }
            
            yield return unit;
            yield return squared;
            yield return cubed;
        }

        var second = new UnitDescription("Second", "s");
        yield return second;

        yield return new UnitDescription("MetersPerSecond", $"{meter.Symbol}/{second.Symbol}", null, new[] { meter.Name, second.Name }, "xx / yy");
        yield return new UnitDescription("Acceleration", $"{meter.Symbol}/{second.Symbol}²", null, new[] { meter.Name, second.Name, second.Name }, "xx / (yy * yy)");

        yield return new UnitDescription("Kelvin", "K");
        
        yield return new UnitDescription("Kilogram", "Kg");
        
        yield return new UnitDescription("Candels", "cd");
        
        yield return new UnitDescription("Ampere", "Amp");
        
        yield return new UnitDescription("Mole", "Mole");
    }

}