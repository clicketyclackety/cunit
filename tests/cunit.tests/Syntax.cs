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
    
}