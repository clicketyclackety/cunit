using BenchmarkDotNet.Attributes;

namespace cunit.benchmarks;

public class Casting_Benchmarks : CUnit_Benchmarks
{

    [Benchmark]
    public void Cunit_CastMeterToInch()
    {
        Meter m1 = 2;
        Inch inch = m1;
    }

    [Benchmark]
    public void UnitsNet_CastMeterToInch()
    {
        var m1 = UnitsNet.Length.FromMeters(2);
        var inch = m1.Inches;
    }

    [Benchmark(Baseline = true)]
    public void Double_CastMeterToInch()
    {
        double m1 = 2;
        double inch = 2 / 0.0254;
    }
    
}