using System.Collections;
using Newtonsoft.Json;
using UnitsNet;
using UnitsNet.Serialization.JsonNet;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace cunit.tests;

public class Serialization
{
    
    [Theory]
    [TestCaseSource(nameof(Units))]
    public void TestSerialization(object unit)
    {
        var json = JsonSerializer.Serialize(unit);
        var newUnit = JsonSerializer.Deserialize(json, unit.GetType());
        
        Assert.Multiple(() =>
        {
            Assert.That(newUnit, Is.EqualTo(unit));
            Assert.That(unit, Is.EqualTo(newUnit));
        });
    }
    
    [Theory]
    [TestCaseSource(nameof(UnitsInEnumerables))]
    public void TestSerializationOfEnumerables(object enumerable)
    {
        var castEnumerable = enumerable as IEnumerable;

        foreach (var enumer in castEnumerable)
        {
            var json = JsonSerializer.Serialize(enumer);
            var newUnit = JsonSerializer.Deserialize(json, enumer.GetType());

            Assert.Multiple(() =>
            {
                Assert.That(newUnit, Is.EqualTo(enumer));
                Assert.That(enumer, Is.EqualTo(newUnit));
            });
        }

        var enumerableJson = JsonSerializer.Serialize(enumerable);
        var deserialized = JsonSerializer.Deserialize(enumerableJson, enumerable.GetType()) as IEnumerable;

        var left = castEnumerable.GetEnumerator();
        var right = deserialized.GetEnumerator();
        while (left.MoveNext() && right.MoveNext())
        {
            Assert.That(left.Current, Is.EqualTo(right.Current));
        }
    }

    public static IEnumerable Units
    {
        get
        {
            yield return new Meter(100);
            yield return new Inch(60);
            yield return new Millimeter(75.45);
            yield return new InchSquared(2, 5);
            yield return new MetersPerSecond(50.2, 20);
            yield return new MeterCubed(65, 76, 90);
            yield return new Acceleration(2, 5.3245, 4);
            yield return new Ampere(254.653);
            yield return new Week(254.653);
        }
    }

    public static IEnumerable UnitsInEnumerables
    {
        get
        {
            yield return new Meter[]  { 1, 2,3 ,4,5 , 500 };
            yield return new MeterCubed[]  { 1, 2,3 ,4,5 , 500 };
            yield return new HashSet<InchSquared>  { 1, 2,3 ,4,5 , 500 };
            yield return new Dictionary<int, Acceleration>  { {1, 20}, {2, 40}, {3, 60}, {4, 70}};
            yield return new List<Inch>  { 1, 2,3 ,4,5 , 500 };
            yield return new Week[]  { 1, 2,3 ,4,5 , 500 };
        }
    }
    
}