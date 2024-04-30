using System.ComponentModel;

namespace cunit.tests;


public readonly struct DoubleMeter : IUnit<Meter>
{
    public double Value { get; }

    public DoubleMeter(double value)
    {
        Value = value;
    }

    public Meter ToSI() => new (Value * 2);
    
    public static implicit operator DoubleMeter(double v) => new DoubleMeter(v);

    public static implicit operator DoubleMeter(Meter v) => v.Value / 2;
    
}

public class CustomUnitTests
{

    [Test]
    public void TestCustomUnit()
    {
        Meter m = 100;
        DoubleMeter dm = m;
        Assert.That(dm.Value, Is.EqualTo(m.Value / 2));
    }

}
