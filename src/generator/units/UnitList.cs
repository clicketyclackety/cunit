using generators;
using generators.files;

namespace generator.units;

public static class UnitList
{

    private static Dictionary<string, GUnit> units;

    public static IEnumerable<GUnit> GetUnits()
    {
        units ??= getUnits().ToDictionary(u => u.Name, u => u);

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
            // TODO : Ratio requires more than just a double!
            // TODO : Add Extensions
            var squared = new GUnit($"{unit.Name}Squared", $"{unit.Symbol}²", meterSquared, new [] {unit.Name, unit.Name}, formula:"<0> * <1>", calculation: $"<vx>, <vy>");
            var cubed = new GUnit($"{unit.Name}Cubed", $"{unit.Symbol}³", meterCubed, new [] {unit.Name, unit.Name, unit.Name }, formula:"<0> * <1> * <2>", calculation: $"<vx>, <vy>, <vz>");
            
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
        
        // TODO : Extension method that converts a thing to a MiliThing or ExaThing?
        yield return new GUnit("MilliSecond", "ms", second, calculation: "<vV> * 1000");
        yield return new GUnit("Hour", "H", second, calculation: "<vV> / 60");
        yield return new GUnit("Day", "D", second, calculation: "<vV> / 60 * 24");
        yield return new GUnit("Week", "W", second, calculation: "<vV> / 60 * 24 * 7");

        // TODO : This is quite weird. Replace complexities with DateTime
        /*
        yield return new GUnit("LeapYear", "H", second, calculation: "<vV> / ((60 * 24 * 7 * 52) + 1)");
        yield return new GUnit("AverageYear", "H", second, calculation: "<vV> / ((60 * 24 * 7 * 52) + 0.25)");
        yield return new GUnit("StandardYear", "H", second, calculation: "<vV> / 60 * 24 * 7 * 52");
        */
        
        #endregion
        
        #region HYBRID UNITS

        yield return new GUnit("MetersPerSecond", $"{meter.Symbol}/{second.Symbol}", null, new[] { meter.Name, second.Name }, formula:"<0> / <1>");
        yield return new GUnit("Acceleration", $"{meter.Symbol}/{second.Symbol}²", null, new[] { meter.Name, second.Name, second.Name }, formula:"<0> / (<1> * <1>)");

        #endregion
        
        #region TEMPERATURE
        
        var kelvin = new GUnit("Kelvin", "K");
        yield return kelvin;
        yield return new GUnit("Celsius", "C", kelvin, calculation: "<vV> + 273.15");
        yield return new GUnit("Fahrenheit", "F", kelvin, calculation: "((<vV> - 32) / 1.79999999) + 273.15");
        
        #endregion
        
        # region MASS
        var kilo = new GUnit("Kilogram", "Kg");
        yield return kilo;
        // yield return new GUnit("MilliGram", "g", kilo, calculation: "<vV> * 0.001 * 0.001");
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
        
        yield return new GUnit("KiloByte", "KB", @byte, calculation:"<vV> * 1024");
        yield return new GUnit("MegaByte", "MB", @byte, calculation:"<vV> * 1024 * 1024");
        yield return new GUnit("GigaByte", "GB", @byte, calculation:"<vV> * 1024 * 1024 * 1024");


        yield return new GUnit("UnknownUnit", "UN");
        
        #endregion

        yield break;


        // TODO : Not found to be viable
        #region Extensions

        // Iterate unit extensions // Maybe move Units into Extension unit?
        yield return new ExtensionUnit("Yotta", 1E24, "Y");
        yield return new ExtensionUnit("Zetta", 1E21, "Z");
        yield return new ExtensionUnit("Exa", 1E19, "E");
        yield return new ExtensionUnit("Peta", 1E15, "P");
        yield return new ExtensionUnit("Tera", 1E12, "T");
        yield return new ExtensionUnit("Giga", 1E9, "G");
        yield return new ExtensionUnit("Mega", 1E6, "M");
        yield return new ExtensionUnit("Kilo", 1E3, "k");
        yield return new ExtensionUnit("Hecto", 1E2, "h");
        yield return new ExtensionUnit("Deca", 1E1, "da");
        // 1E0
        yield return new ExtensionUnit("Deci", 1E-1, "d");
        yield return new ExtensionUnit("Centi", 1E-2, "c");
        yield return new ExtensionUnit("Milli", 1E-3, "m");
        yield return new ExtensionUnit("Micro", 1E-6, "µ");
        yield return new ExtensionUnit("Pico", 1E-9, "n");
        yield return new ExtensionUnit("Nano", 1E-12, "p");
        yield return new ExtensionUnit("Femto", 1E-15, "f");
        yield return new ExtensionUnit("Atto", 1E-18, "a");
        yield return new ExtensionUnit("Zepto", 1E-21, "z");
        yield return new ExtensionUnit("Yokto", 1E-24, "y");

        #endregion

    }

}