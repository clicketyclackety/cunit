using BenchmarkDotNet.Attributes;

namespace cunit.benchmarks;

public class CacheHashCode_Benchmarks : CUnit_Benchmarks
{
    const int count = 1000;

    [Benchmark]
    public void Cunit_CacheHashCodeMeter()
    {
        Meter m1 = 2;
        for(int i = 0; i < count; i++)
        {
            int hashCode = m1.GetHashCode();
        }
    }

    [Benchmark]
    public void UnitsNet_CacheHashCodeMeter()
    {
        var m1 = UnitsNet.Length.FromMeters(2);
        for(int i = 0; i < count; i++)
        {
            int hashCode = m1.GetHashCode();
        }
    }

    [Benchmark(Baseline = true)]
    public void Double_CacheHashCodeMeter()
    {
        double m1 = 2;
        for(int i = 0; i < count; i++)
        {
            int hashCode = m1.GetHashCode();
        }
    }
    
}