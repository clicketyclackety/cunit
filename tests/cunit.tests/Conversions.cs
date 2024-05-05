using System.Reflection.Metadata;

namespace cunit.tests;

public class Conversions
{

    public static IEnumerable<IUnit[]> ConversionData()
    {
        yield return new IUnit[] { new Radian(1), new Degree(Constants.PI / 180), };
        yield return new IUnit[] { new Meter(1), new Kilometer(0.001), new Centimeter(100), new Millimeter(1000), new Foot(3.28084), new Inch(39.37008), };
        yield return new IUnit[] { new InchSquared(1, 1), new MillimeterSquared(25.4, 25.4) };
        yield return new IUnit[] { new InchCubed(1, 1, 1), new MillimeterCubed(25.4, 25.4, 25.4) };
        yield return new IUnit[] { new Second(60 * 60 * 7 * 24), new MilliSecond(1000 * 60  * 60 * 7 * 24), new Minute(60 * 7 * 24), new Hour(7 * 24), new Day(7), new Week(1), };
        
        // yield return new IUnit[] { new MetersPerSecond(1), new MetersPerSecond(1), };
        
        yield return new IUnit[] { new Kelvin(233.15), new Celsius(-40), new Fahrenheit(-40), };
        // yield return new IUnit[] { new Kilogram(1), new Milligram(1000 * 1000), new Gram(1000), new Tonne(0.001), new Ounce(35.27396), new Pound(2.20462), };
        
        yield return new IUnit[] { new Candela(1), new Candela(1), };
        yield return new IUnit[] { new Ampere(1), new Ampere(1), };
        yield return new IUnit[] { new Mole(1), new Mole(1) };
        
        yield return new IUnit[] { new Byte(1024 * 1024 * 1024), new Kilobyte(1024 * 1024), new Megabyte(1024), new Gigabyte(1), };
    }

    [Test]
    [TestCaseSource(nameof(ConversionData))]
    public void ConversionEquality(IUnit[] units)
    {
        if (units.Length == 1) return;

        for(int i = 0; i < units.Length - 1; i++)
        {
            var iP = i + 1;
            
            Assert.That(units[i], Is.EqualTo(units[i]));
            Assert.That(units[iP], Is.EqualTo(units[iP]));

            Assert.That(units[i], Is.EqualTo(units[iP]));
            Assert.That(units[iP], Is.EqualTo(units[i]));
        }
    }

}