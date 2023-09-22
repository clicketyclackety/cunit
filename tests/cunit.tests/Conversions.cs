namespace cunit.tests;

public class Conversions
{

    [Test]
    public void DistanceConversions()
    {
        Inch inch = 1;
        Millimeter mm = 25.4;

        Assert.That(mm, Is.EqualTo(inch));
        Assert.That(inch, Is.EqualTo(mm));
    }

    [Test]
    public void AreaConversion()
    {
        InchSquared i2 = new(1, 1);
        MillimeterSquared mm2 = new(25.4, 25.4);

        var val = mm2 - i2;
        
        Assert.That(mm2, Is.EqualTo(i2));
        Assert.That(i2, Is.EqualTo(mm2));
    }
    
}