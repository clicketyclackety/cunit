using BenchmarkDotNet.Attributes;

namespace cunit.benchmarks;

public class Equality_Benchmarks : CUnit_Benchmarks
{

    [Benchmark]
    public void Cunit_EqualityMeter()
    {
        Meter m1 = 2;
        Meter m2 = 2;

        var equalsequals = m1 == m2;
        var dotEquals = m1.Equals(m2);
    }

    [Benchmark]
    public void UnitsNet_EqualityMeter()
    {
        var m1 = UnitsNet.Length.FromMeters(2);
        var m2 = UnitsNet.Length.FromMeters(2);

        var equalsequals = m1 == m2;
        var dotEquals = m1.Equals(m2);
    }

    [Benchmark(Baseline = true)]
    public void Double_EqualityMeter()
    {
        double m1 = 2;
        double m2 = 2;

        var equalsequals = m1 == m2;
        var dotEquals = m1.Equals(m2);
    }
    
}