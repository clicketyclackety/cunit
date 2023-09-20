namespace cunit.tests;

public class Tests
{

    [Test]
    public void TestMeter()
    {
        Meter m = 100;
        Centimeter cm = m;
        Millimeter mm = m;
        
        Assert.That(m, Is.EqualTo(mm));
        Assert.That(m, Is.EqualTo(cm));
    }

    [Test]
    public void TestArea()
    {
        Meter m = 100;
        Centimeter cm = m;
        Millimeter mm = m;

        MeterSquared sm = m * m;
        CentimeterSquared scm = cm * cm;
        MillimeterSquared smm = mm * mm;
    }

    [Test]
    public void TestMathmatics()
    {
        Meter m1 = 100;
        Meter m2 = 200;
        MeterSquared ms = m1 * m2;

        Farenheight f = 30;
        Celcius c = 42;
        Kelvin k = c - f;
    }
    
}