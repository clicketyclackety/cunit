using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using UnitsNet;
using UnitsNet.Serialization.JsonNet;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace cunit.benchmarks;

public class Serialize_Benchmarks : CUnit_Benchmarks
{

    [Benchmark]
    public void Cunit_SerializeMeters()
    {
        Kilogram kg = 2;
        var json = JsonSerializer.Serialize(kg);
        var kg_2 = JsonSerializer.Deserialize<Meter>(json);
    }

    [Benchmark]
    public void UnitsNet_SerializeMeter()
    {
        var jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
        jsonSerializerSettings.Converters.Add(new UnitsNetIQuantityJsonConverter());

        string json = JsonConvert.SerializeObject(new { Name = "Raiden", Weight = Mass.FromKilograms(90) }, jsonSerializerSettings);

        object kg_2 = JsonConvert.DeserializeObject(json);
    }

    [Benchmark(Baseline = true)]
    public void Double_SerializeMeter()
    {
        double kg = 2;
        var json = JsonSerializer.Serialize(kg);
        var kg_2 = JsonSerializer.Deserialize<double>(json);
    }
    
}