using BenchmarkDotNet.Attributes;

namespace cunit.benchmarks;

public class GreaterThan_Benchmarks : CUnit_Benchmarks
{

    [Benchmark]
    public void Cunit_GreaterThanTwoMeters()
    {
        Meter m1 = 2;
        Meter m2 = 2;
        var m3 = m1 > m2;
    }

    [Benchmark]
    public void UnitsNet_GreaterThanTwoMeters()
    {
        var m1 = UnitsNet.Length.FromMeters(2);
        var m2 = UnitsNet.Length.FromMeters(2);
        var m3 = m1 > m2;
    }

    [Benchmark(Baseline = true)]
    public void Double_GreaterThanTwoMeters()
    {
        double m1 = 2;
        double m2 = 2;
        var m3 = m1 > m2;
    }
    
}