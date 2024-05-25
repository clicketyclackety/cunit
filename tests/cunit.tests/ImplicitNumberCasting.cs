namespace cunit.tests;

public class ImplicitNumberCasting
{

    [Test]
    public void DoubleCast()
    {
        double value = 200.0;
        Meter m = value;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }

    [Test]
    public void FloatCast()
    {
        float value = 200.0f;
        Meter m = value;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }

    [Test]
    public void DecimalCast()
    {
        decimal value = 200.01m;
        Meter m = value;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }

    [Test]
    public void LongCast()
    {
        long value = 200;
        Meter m = value;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }

    [Test]
    public void IntCast()
    {
        int value = 200;
        Meter m = value;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }
    
}