namespace cunit.tests;

public class ExplicitNumberCasting
{

    [Test]
    public void DoubleCast()
    {
        Meter m = 200.0;
        var value = (double)m;

        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }

    [Test]
    public void FloatCast()
    {
        Meter m = 200.0f;
        var value = (float)m;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }

    [Test]
    public void DecimalCast()
    {
        Meter m = 200.01m;
        var value = (decimal)m;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }

    [Test]
    public void LongCast()
    {
        Meter m = 200;
        var value = (long)m;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }

    [Test]
    public void IntCast()
    {
        Meter m = 200;
        var value = (int)m;
        Assert.True(m.Equals(value));
        Assert.True(m == value);
    }
    
}