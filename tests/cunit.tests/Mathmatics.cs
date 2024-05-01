namespace cunit.tests;

public class Mathmatics
{

    [Test]
    public void Distance()
    {
        Meter m = 1;
        Centimeter cm = 100;
        Millimeter mm = 1_000;
        Kilometer km = 0.001;
        
        Assert.That(m, Is.EqualTo(m));
        Assert.That(m, Is.EqualTo(mm));
        Assert.That(m, Is.EqualTo(cm));
        Assert.That(m, Is.EqualTo(km));
        Assert.That(m, Is.EqualTo((Meter)cm));
        Assert.That(m, Is.EqualTo((Meter)mm));
        Assert.That(m, Is.EqualTo((Meter)km));
        Assert.That(m, Is.EqualTo(cm.ToSI()));
        Assert.That(m == mm.ToSI(), Is.True);
        Assert.That(m, Is.EqualTo(km));
    }

    [Test]
    public void Temperature()
    {
        Fahrenheit f = -40;
        Celsius c = -40;
        Kelvin k = 233.15;

        Assert.That(k, Is.EqualTo(k));
        
        Assert.That(k, Is.EqualTo(c));
        Assert.That(c, Is.EqualTo(k));
        
        Assert.That(f, Is.EqualTo(k));
        Assert.That(k, Is.EqualTo(f));
        
        Assert.That(c, Is.EqualTo(f));
        Assert.That(f, Is.EqualTo(c));
        
        Assert.That(k, Is.EqualTo(k));
        
        Assert.That(k, Is.EqualTo(c));
        Assert.That(c, Is.EqualTo(k));
        
        Assert.That(f, Is.EqualTo(k));
        Assert.That(k, Is.EqualTo(f));
        
        Assert.That(c, Is.EqualTo(f));
        Assert.That(f, Is.EqualTo(c));
        
        Assert.That(k, Is.EqualTo(k));
        
        Assert.That(k, Is.EqualTo(c));
        Assert.That(c, Is.EqualTo(k));
        
        Assert.That(f, Is.EqualTo(k));
        Assert.That(k, Is.EqualTo(f));
        
        Assert.That(c, Is.EqualTo(f));
        Assert.That(f, Is.EqualTo(c));
    }

    [Test]
    public void Memory()
    {
        Bit b = 8.0 * 1024.0 * 1024.0 * 1024.0;
        Byte B = 1024.0 * 1024.0 * 1024.0;
        KiloByte KB = 1024.0 * 1024.0;
        MegaByte MB = 1024.0;
        GigaByte GB = 1.0;
        
        Assert.That(B, Is.EqualTo(b));
        Assert.That(B, Is.EqualTo(KB));
        Assert.That(B, Is.EqualTo(MB));
        Assert.That(B, Is.EqualTo(GB));

        var km = Kilo.Meter(200);

        var meter = km.ToSI();

        var m = km / meter;
    }
    
}