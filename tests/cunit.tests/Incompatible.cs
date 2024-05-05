namespace cunit.tests;

public class Incompatible
{

    public static IEnumerable<object[]> Incompatibles()
    {
        yield return new object[] { new Radian(1), new Meter(1) };
        yield return new object[] { new Radian(1), new Byte(1) };
        yield return new object[] { new Radian(1), new Celsius(1) };
        yield return new object[] { new Radian(1), new Candela(1) };
        yield return new object[] { new Radian(1), new Ampere(1) };
        yield return new object[] { new Radian(1), new Mole(1) };
        yield return new object[] { new Radian(1), new Pound(1) };

        yield return new object[] { new Celsius(1), new Meter(1) };
        yield return new object[] { new Celsius(1), new Pound(1) };

        yield return new object[] { new Byte(1), new Meter(1) };
        yield return new object[] { new Byte(1), new Radian(1) };
        yield return new object[] { new Byte(1), new Celsius(1) };
        yield return new object[] { new Gigabyte(1), new Candela(1) };
        yield return new object[] { new Kilobyte(1), new Ampere(1) };
        yield return new object[] { new Megabyte(1), new Mole(1) };
        yield return new object[] { new Megabyte(1), new Pound(1) };

        yield return new object[] { new Day(1), new Meter(1) };
        yield return new object[] { new Second(1), new Radian(1) };
        yield return new object[] { new Ampere(1), new Celsius(1) };
        yield return new object[] { new Pound(1), new Candela(1) };
        yield return new object[] { new Radian(1), new Ampere(1) };
        yield return new object[] { new Celsius(1), new Mole(1) };
        yield return new object[] { new Meter(1), new Pound(1) };
        
        yield return new object[] { new Megabyte(1), new MeterSquared(1) };
    }

    [Test]
    [TestCaseSource(nameof(Incompatibles))]
    public void IncompatibleUnits(IUnit left, IUnit right)
    {
        dynamic l = left;
        dynamic r = right;

        try
        {
            var result = l * r;
            Assert.Fail($"Left unit {left} and right unit {right} should not be compatible");
        }
        catch(Exception ex)
        {
            Assert.That(ex, Is.Not.Null);
        }
        
        try
        {
            var result = l / r;
            Assert.Fail($"Left unit {left} and right unit {right} should not be compatible");
        }
        catch(Exception ex)
        {
            Assert.That(ex, Is.Not.Null);
        }
        
        try
        {
            var result = l - r;
            Assert.Fail($"Left unit {left} and right unit {right} should not be compatible");
        }
        catch(Exception ex)
        {
            Assert.That(ex, Is.Not.Null);
        }
        
        try
        {
            var result = l + r;
            Assert.Fail($"Left unit {left} and right unit {right} should not be compatible");
        }
        catch(Exception ex)
        {
            Assert.That(ex, Is.Not.Null);
        }
        
        try
        {
            var result = l ^ r;
            Assert.Fail($"Left unit {left} and right unit {right} should not be compatible");
        }
        catch(Exception ex)
        {
            Assert.That(ex, Is.Not.Null);
        }
    }

}
