using BenchmarkDotNet.Attributes;

namespace cunit.benchmarks;

public class Add_Benchmarks : CUnit_Benchmarks
{

    [Benchmark]
    public void Cunit_AddTwoMeters()
    {
        Meter m1 = 2;
        Meter m2 = 2;
        Meter m3 = m1 + m2;
    }

    [Benchmark]
    public void UnitsNet_AddTwoMeters()
    {
        var m1 = UnitsNet.Length.FromMeters(2);
        var m2 = UnitsNet.Length.FromMeters(2);
        UnitsNet.Length len = m1 + m2;
    }

    [Benchmark(Baseline = true)]
    public void Double_AddTwoMeters()
    {
        double m1 = 2;
        double m2 = 2;
        double m3 = m1 + m2;
    }
    
}