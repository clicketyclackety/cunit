using BenchmarkDotNet.Attributes;

namespace cunit.benchmarks;

public class HashCode_Benchmarks : CUnit_Benchmarks
{

    [Benchmark]
    public void Cunit_HashCodeMeter()
    {
        Meter m1 = 2;
        int hashCode = m1.GetHashCode();
    }

    [Benchmark]
    public void UnitsNet_HashCodeMeter()
    {
        var m1 = UnitsNet.Length.FromMeters(2);
        int hashCode = m1.GetHashCode();
    }

    [Benchmark(Baseline = true)]
    public void Double_HashCodeMeter()
    {
        double m1 = 2;
        int hashCode = m1.GetHashCode();
    }
    
}