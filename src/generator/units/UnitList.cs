using generators;
using generators.files;

namespace generator.units;

// TODO : Make sure all of this works in System.Text.Json!
public static class UnitList
{
    public record UnitDescription(string Name,
                                        string Symbol,
                                        UnitDescription? BaseUnit = null,
                                        string[]? Dimensions = null,
                                        string? Formula = "",
                                        string Calculation = "value * 1");

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
        // TODO : Pluralisation
        
        #region MISC SPATIAL

        var rad = new UnitDescription("Radian", "R", Calculation: "180/cunit.Constants.PI");
        yield return rad;
        yield return new UnitDescription("Degree", "°", rad, Calculation: "value * (180/cunit.Constants.PI)");
        
        #endregion
        
        #region DISTANCE/AREA/VOLUME
        
        var meter = new UnitDescription("Meter", "m");
        var centimeter = new UnitDescription("Centimeter", "cm", meter, Calculation:"value / 100");
        var millimeter = new UnitDescription("Millimeter", "mm", meter, Calculation:"value / 1000");
        var foot = new UnitDescription("Foot", "ft", meter, Calculation:"value *  1 / 39.37");
        var inch = new UnitDescription("Inch", "in", meter, Calculation:"value *  1 / 3.281");
        
        UnitDescription[] distanceUnits = new []
        {
            meter,
            centimeter,
            millimeter,
            inch,
            foot
        };

        UnitDescription? meterSquared = null;
        UnitDescription? meterCubed = null;
        foreach (var unit in distanceUnits)
        {
            // TODO : Fix Ratios, they require powers & base unit ratios
            // TODO : Ratio requires more than just a double! 
            var squared = new UnitDescription($"{unit.Name}Squared", "m²", meterSquared, new [] {unit.Name, unit.Name}, "xx * yy"); 
            var cubed = new UnitDescription($"{unit.Name}Cubed", "m³", meterCubed, new [] {unit.Name, unit.Name, unit.Name }, "xx * yy * zz");
            
            if (unit.Name.Equals(meter.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                meterSquared = squared;
                meterCubed = cubed;
            }
            
            yield return unit;
            yield return squared;
            yield return cubed;
        }

        #endregion
        
        
        #region TIME
        
        var second = new UnitDescription("Second", "s");
        yield return second;
        
        yield return new UnitDescription("MilliSecond", "s", second, Calculation: "value * 1000");
        yield return new UnitDescription("Hour", "H", second, Calculation: "value / 60");
        yield return new UnitDescription("Day", "H", second, Calculation: "value / 60 * 24");
        yield return new UnitDescription("Week", "H", second, Calculation: "value / 60 * 24 * 7");
        
        #endregion
        
        #region HYBRID UNITS

        yield return new UnitDescription("MetersPerSecond", $"{meter.Symbol}/{second.Symbol}", null, new[] { meter.Name, second.Name }, "xx / yy");
        yield return new UnitDescription("Acceleration", $"{meter.Symbol}/{second.Symbol}²", null, new[] { meter.Name, second.Name, second.Name }, "xx / (yy * yy)");

        #endregion
        
        #region TEMPERATURE
        
        var kelvin = new UnitDescription("Kelvin", "K");
        yield return kelvin;
        yield return new UnitDescription("Celcius", "C", kelvin, Calculation: "value - 273.15");
        yield return new UnitDescription("Farenheight", "F", kelvin, Calculation: "(1.8 * (value - 273.15)) + 32");
        
        #endregion
        
        # region MASS
        
        var kilo = new UnitDescription("Kilogram", "Kg");
        yield return kilo;
        yield return new UnitDescription("Gram", "g", kilo, Calculation: "value * 0.001");
        yield return new UnitDescription("Tonne", "T", kilo, Calculation: "value * 1000");

        yield return new UnitDescription("Ounce", "oz", kilo, Calculation: "value * 0.02834952");
        yield return new UnitDescription("Pound", "lb", kilo, Calculation: "value * 0.02834952 / 16");
        
        #endregion
        
        yield return new UnitDescription("Candela", "cd");
        
        yield return new UnitDescription("Ampere", "A");
        
        yield return new UnitDescription("Mole", "Mol");
        
        #region MEMORY
        
        var @byte = new UnitDescription("Byte", "B");
        yield return @byte;
        
        yield return new UnitDescription("Bit", "b", @byte, Calculation:"value / 8");
        
        yield return new UnitDescription("KiloByte", "B", @byte, Calculation:"value * 1024");
        yield return new UnitDescription("MegaByte", "MB", @byte, Calculation:"value * 1024 * 1024");
        yield return new UnitDescription("GigaByte", "GB", @byte, Calculation:"value * 1024 * 1024 * 1024");
        
        #endregion
    }

}