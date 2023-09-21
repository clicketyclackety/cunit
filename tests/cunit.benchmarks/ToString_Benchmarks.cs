using System.Globalization;
using BenchmarkDotNet.Attributes;

namespace cunit.benchmarks;

public class ToString_Benchmarks : CUnit_Benchmarks
{

    [Benchmark]
    public void Cunit_ToString()
    {
        Meter m1 = 2;
        var ms = m1.ToString();
        var mf = m1.ToString("G");
        var mfc = m1.ToString("G", CultureInfo.InvariantCulture);
    }

    [Benchmark]
    public void UnitsNet_ToString()
    {
        var m1 = UnitsNet.Length.FromMeters(2);
        var ms = m1.ToString();
        var mf = m1.ToString("G");
        var mfc = m1.ToString("G", CultureInfo.InvariantCulture);
    }

    [Benchmark(Baseline = true)]
    public void Double_ToString()
    {
        double m1 = 2;
        var ms = m1.ToString();
        var mf = m1.ToString("G");
        var mfc = m1.ToString("G", CultureInfo.InvariantCulture);
    }
    
}