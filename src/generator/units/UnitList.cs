using generators;
using generators.files;

namespace generator.units;

public static class UnitList
{

    private static Dictionary<string, GUnit> units;

    public static IEnumerable<GUnit> GetUnits()
    {
        if (units is null)
            units = getUnits().ToDictionary(u => u.Name, u => u);

        return units.Values;
    }

    public static IEnumerable<GUnit> GetUnitsUsingThis(GUnit gUnit)
    {
        foreach (var unitItem in GetUnits())
        {
            if (gUnit.Dimensions is null || gUnit.Dimensions.Length < 1)
                continue;

            if (!gUnit.Dimensions.Contains(gUnit.Name))
                continue;

            yield return unitItem;
        }
    }

    public static GUnit GetUnit(string name) => units[name];

    private static IEnumerable<GUnit> getUnits()
    {
        // what is it
        // What is it made of
        // How does it relate to an SI unit?
        // TODO : Pluralisation
        
        #region MISC SPATIAL

        var rad = new GUnit("Radian", "R", calculation: "180/cunit.Constants.PI");
        yield return rad;
        yield return new GUnit("Degree", "°", rad, calculation: "<vV> * (180/cunit.Constants.PI)");
        
        #endregion
        
        #region DISTANCE/AREA/VOLUME
        
        var meter = new GUnit("Meter", "m");
        var kilometer = new GUnit("Kilometer", "km", meter, calculation: "<vV> * 1000");
        var centimeter = new GUnit("Centimeter", "cm", meter, calculation:"<vV> / 100");
        var millimeter = new GUnit("Millimeter", "mm", meter, calculation:"<vV> / 1000");
        var foot = new GUnit("Foot", "ft", meter, calculation:"<vV> *  0.3048");
        var inch = new GUnit("Inch", "in", meter, calculation:"<vV> *  0.0254");
        
        GUnit[] distanceUnits = new []
        {
            meter,
            kilometer,
            centimeter,
            millimeter,
            inch,
            foot
        };

        GUnit? meterSquared = null;
        GUnit? meterCubed = null;
        foreach (var unit in distanceUnits)
        {
            // TODO : Fix Ratios, they require powers & base unit ratios
            // TODO : Ratio requires more than just a double! 
            var squared = new GUnit($"{unit.Name}Squared", "m²", meterSquared, new [] {unit.Name, unit.Name}, formula:"<0> * <1>", calculation: $"<vx>, <vy>");
            var cubed = new GUnit($"{unit.Name}Cubed", "m³", meterCubed, new [] {unit.Name, unit.Name, unit.Name }, formula:"<0> * <1> * <2>", calculation: $"<vx>, <vy>, <vz>");
            
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
        
        var second = new GUnit("Second", "s");
        yield return second;
        
        yield return new GUnit("MilliSecond", "s", second, calculation: "<vV> * 1000");
        yield return new GUnit("Hour", "H", second, calculation: "<vV> / 60");
        yield return new GUnit("Day", "H", second, calculation: "<vV> / 60 * 24");
        yield return new GUnit("Week", "H", second, calculation: "<vV> / 60 * 24 * 7");
        
        #endregion
        
        #region HYBRID UNITS

        yield return new GUnit("MetersPerSecond", $"{meter.Symbol}/{second.Symbol}", null, new[] { meter.Name, second.Name }, formula:"<0> / <1>");
        yield return new GUnit("Acceleration", $"{meter.Symbol}/{second.Symbol}²", null, new[] { meter.Name, second.Name, second.Name }, formula:"<0> / (<1> * <1>)");

        #endregion
        
        #region TEMPERATURE
        
        var kelvin = new GUnit("Kelvin", "K");
        yield return kelvin;
        yield return new GUnit("Celcius", "C", kelvin, calculation: "<vV> + 273.15");
        yield return new GUnit("Farenheight", "F", kelvin, calculation: "((<vV> - 32) / 1.79999999) + 273.15");
        
        #endregion
        
        # region MASS
        
        var kilo = new GUnit("Kilogram", "Kg");
        yield return kilo;
        yield return new GUnit("Gram", "g", kilo, calculation: "<vV> * 0.001");
        yield return new GUnit("Tonne", "T", kilo, calculation: "<vV> * 1000");

        yield return new GUnit("Ounce", "oz", kilo, calculation: "<vV> * 0.02834952");
        yield return new GUnit("Pound", "lb", kilo, calculation: "<vV> * 0.02834952 / 16");
        
        #endregion
        
        yield return new GUnit("Candela", "cd");
        
        yield return new GUnit("Ampere", "A");
        
        yield return new GUnit("Mole", "Mol");
        
        #region MEMORY
        
        var @byte = new GUnit("Byte", "B");
        yield return @byte;
        
        yield return new GUnit("Bit", "b", @byte, calculation:"<vV> / 8");
        
        yield return new GUnit("KiloByte", "B", @byte, calculation:"<vV> * 1024");
        yield return new GUnit("MegaByte", "MB", @byte, calculation:"<vV> * 1024 * 1024");
        yield return new GUnit("GigaByte", "GB", @byte, calculation:"<vV> * 1024 * 1024 * 1024");
        
        #endregion
    }

}