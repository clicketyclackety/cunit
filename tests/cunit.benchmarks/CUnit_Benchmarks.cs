using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace cunit.benchmarks;

[MemoryDiagnoser]
[ThreadingDiagnoser]
// [SimpleJob(RuntimeMoniker.Net70)]
//[SimpleJob(RuntimeMoniker.Net481)]
// [SimpleJob(RuntimeMoniker.Wasm)]
public abstract class CUnit_Benchmarks
{
    
}