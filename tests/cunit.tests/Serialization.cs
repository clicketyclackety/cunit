using System.Collections;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace cunit.tests;

public class Serialization
{
    
    [Test]
    public void TestUniversalSerialization_System()
    {
        Gram gram = 20;
        var json = JsonSerializer.Serialize(gram);
        var newGram = JsonSerializer.Deserialize(json, gram.GetType());

        var newKilogram = JsonSerializer.Deserialize(json, typeof(Kilogram));
        
        Assert.Multiple(() =>
        {
            Assert.That(gram, Is.EqualTo(newGram));
            Assert.That(newKilogram, Is.EqualTo(gram));
        });
    }
    
    [Test]
    public void TestUniversalSerialization_Newtonsoft()
    {
        Gram gram = 20;
        
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(gram);
        var newGram = Newtonsoft.Json.JsonConvert.DeserializeObject<Gram>(json);

        var newKilogram = Newtonsoft.Json.JsonConvert.DeserializeObject<Kilogram>(json);
        
        Assert.Multiple(() =>
        {
            Assert.That(gram, Is.EqualTo(newGram));
            Assert.That(newKilogram, Is.EqualTo(gram));
        });
    }
    
    [Theory]
    [TestCaseSource(nameof(Units))]
    public void TestSerialization_System(object unit)
    {
        var json = JsonSerializer.Serialize(unit);
        var newUnit = JsonSerializer.Deserialize(json, unit.GetType());
        
        Assert.That(newUnit, Is.EqualTo(unit));
        Assert.That(unit, Is.EqualTo(newUnit));
    }
    
    [Theory]
    [TestCaseSource(nameof(Units))]
    public void TestSerialization_Newtonsoft(object unit)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(unit);
        var newUnit = Newtonsoft.Json.JsonConvert.DeserializeObject(json, unit.GetType());
        
        Assert.That(newUnit, Is.EqualTo(unit));
        Assert.That(unit, Is.EqualTo(newUnit));
    }
    
    [Theory]
    [TestCaseSource(nameof(UnitsInEnumerables))]
    public void TestSerializationOfEnumerables_System(IEnumerable enumerable)
    {
        foreach (var enumer in enumerable)
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
        var type = enumerable.GetType().Name;
        var deserialized = JsonSerializer.Deserialize(enumerableJson, enumerable.GetType()) as IEnumerable;

        var left = enumerable.GetEnumerator();
        var right = deserialized.GetEnumerator();
        while (left.MoveNext() && right.MoveNext())
        {
            Assert.That(left.Current, Is.EqualTo(right.Current));
        }
    }
    
    [Theory]
    [TestCaseSource(nameof(UnitsInEnumerables))]
    public void TestSerializationOfEnumerables_Newtonsoft(IEnumerable enumerable)
    {
        foreach (var enumer in enumerable)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(enumer);
            var newUnit = Newtonsoft.Json.JsonConvert.DeserializeObject(json, enumer.GetType());

            Assert.Multiple(() =>
            {
                Assert.That(newUnit, Is.EqualTo(enumer));
                Assert.That(enumer, Is.EqualTo(newUnit));
            });
        }

        var enumerableJson = Newtonsoft.Json.JsonConvert.SerializeObject(enumerable);
        var type = enumerable.GetType().Name;
        var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject(enumerableJson, enumerable.GetType()) as IEnumerable;

        var left = enumerable.GetEnumerator();
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
            yield return new MeterCubed(65, 76, 90);
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
            yield return new List<Inch>  { 1, 2,3 ,4,5 , 500 };
            yield return new Week[]  { 1, 2,3 ,4,5 , 500 };
        }
    }
    
}