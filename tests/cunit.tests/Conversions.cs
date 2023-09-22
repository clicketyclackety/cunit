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
        
        Assert.That(mm2, Is.EqualTo(i2));
        Assert.That(i2, Is.EqualTo(mm2));
    }

    [Test]
    public void VolumeConversion()
    {
        InchCubed i3 = new(1, 1, 1);
        MillimeterCubed mm3 = new(25.4, 25.4, 25.4);
        
        Assert.That(mm3, Is.EqualTo(i3));
        Assert.That(i3, Is.EqualTo(mm3));
    }

    [Test]
    public void MassConversion()
    {
        Kilogram kg = 1;
        Gram g = 1000;
        
        Assert.That(kg, Is.EqualTo(g));
        Assert.That(g, Is.EqualTo(kg));
    }

    [Test]
    public void TemperatureConversion()
    {
        Celcius c = -40;
        Farenheight f = -40;
        
        Assert.That(c, Is.EqualTo(f));
        Assert.That(f, Is.EqualTo(c));
    }
    
}