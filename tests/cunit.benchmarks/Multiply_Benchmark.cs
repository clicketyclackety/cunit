using BenchmarkDotNet.Attributes;

namespace cunit.benchmarks;

public class Multiply_Benchmark : CUnit_Benchmarks
{

    [Benchmark]
    public void Cunit_MultiplyTwoMeters()
    {
        Meter m1 = 2;
        Meter m2 = 2;
        var m3 = m1 * m2;
    }

    [Benchmark]
    public void UnitsNet_MultiplyTwoMeters()
    {
        var m1 = UnitsNet.Length.FromMeters(2);
        var m2 = UnitsNet.Length.FromMeters(2);
        UnitsNet.Area len = m1 * m2;
    }

    [Benchmark(Baseline = true)]
    public void Double_MultiplyTwoMeters()
    {
        double m1 = 2;
        double m2 = 2;
        double m3 = m1 * m2;
    }
    
}