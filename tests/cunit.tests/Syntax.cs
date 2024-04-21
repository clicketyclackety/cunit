namespace cunit.tests;

public class Tests
{

    [Test]
    public void TestMeter()
    {
        Meter m = 100;
        Centimeter cm = m;
        Millimeter mm = m;
        Kilometer km = m;
        
        Assert.That(m, Is.EqualTo(mm));
        Assert.That(m, Is.EqualTo(cm));
        Assert.That(m, Is.EqualTo(km));
        
        var meq = m.Equals(m);
        var cmqeq = cm.Equals(cm);
        var mmeq = mm.Equals(mm);
        var kmeq = km.Equals(m);
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

        Fahrenheit f = 30;
        Celsius c = 42;
        Kelvin k = (c - f) * 20; 
    }

    [Test]
    public void TestTupleCasting()
    {
        MeterCubed m3 = 2000;
        (Meter, Meter, Meter) mmm = m3;
        MeterCubed m4 = new(mmm);

        FootCubed fc = m4;
        // TODO : How do we sort that the divider may not equal that dimension?
        // TODO : Where do those dimensions and those values go?
        FootSquared fs = m4 / new Meter(40);
    }
    
    [Test]
    public void TestGreatherThan()
    {
        Meter m = 100;
        Centimeter cm = 200;
        if (m > cm ||
            m < cm ||
            m == cm ||
            m != cm ||
            cm == m ||
            cm == cm ||
            cm >= m)
        {
            
        }
    }
    
}