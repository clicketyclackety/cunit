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
        
        Assert.That(m == m, Is.True);
        Assert.That(m == mm, Is.True);
        Assert.That(m == cm, Is.True);
        Assert.That(m == km, Is.True);
        Assert.That(m == (Meter)cm, Is.True);
        Assert.That(m == (Meter)mm, Is.True);
        Assert.That(m == (Meter)km, Is.True);
        Assert.That(m == cm.ToSI(), Is.True);
        Assert.That(m == mm.ToSI(), Is.True);
        Assert.That(m == km, Is.True);
    }

    [Test]
    public void Temperature()
    {
        Farenheight f = -40;
        Celcius c = -40;
        Kelvin k = 273.15;

        Assert.That(k == c);

        Assert.That(c == f);
    }

    [Test]
    public void Memory()
    {
        Bit b = 8;
        Byte B = 1;
        KiloByte KB = 1/1024;
        MegaByte MB = 1/(1024 * 1024);
        GigaByte GB = 1/(1204 * 1024 * 1024);
        
        Assert.That(B == b);
        Assert.That(B == KB);
        Assert.That(B == MB);
        Assert.That(B == GB);
    }
    
}