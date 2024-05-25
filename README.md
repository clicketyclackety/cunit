# Preamble
cunit is a general units library for C#. I've found other unit libraries to have the following issues that have always bothered me;
- Large (1-2mb+)
- Ineligant syntax
- Hard to use
- Use of Mutable and nullables
- Too many unecessary units

As such cunit is designed to be a lightweight, efficient, intuitive and immutable alternative.

Let's start with a simple example dealing with temperature.
```csharp
Farenheight f = 40;
Celcius c = 32;
Kelvin k = (c - f) * 2;
```
We quickly see that cunit is designed to work like, and alongside standard dotnet numbers. There are no methods to convert one measurement into another, it happens seamlessly. The only thing cunit **does not do implictly** cast to is a double. You must call `myUnit.Value` or explicitly cast it `(double)myUnit`. Avoiding implicit casts ensures better accuracy in calculations as units 

Here's a more complex example, that showcases many of the available operations cunit offers.
```csharp
Meter m1 = 200;
Meter m2 = 100f;
Meter m3 = 50m;
Kilogram kg = 50.0;

var result = ((m1 + m2) * m3) / (m2++) * (m3 % 20) / (--m1) * m2 * m1 * kg;
```
The end result is a KilogramPerMeterCubed. A complex, 4 dimensional unit. If we tried to divide the result by a meter, the compiler would not let us. After all a KilogramPerMeterSquared does not exist.

For more syntax examples, see this test class [Syntax](https://github.com/clicketyclackety/cunit/blob/main/tests/cunit.tests/Syntax.cs).


# Serializing
cunit has native `System.Text.Json` support (but not `Newtonsoft.Json` currently), you can serialize and deserialize any unit with ease.
``` csharp
Kilogram kg = 2;
var json = JsonSerializer.Serialize(kg);
var new_kg = JsonSerializer.Deserialize<Kilogram>(json);
```

You can also deserialize a unit to a different unit, which will still correctly convert the value for you.
``` csharp
Kilogram kg = 2;
var json = JsonSerializer.Serialize(kg);
var gram = JsonSerializer.Deserialize<Gram>(json);
```

# Performance
All of cunits units are precomputed readonly structs. This means;
- GetHashCode() has no extra overhead
- Every unit you create lives on the stack
- Cunit is (almost) as fast as using doubles, decimals, etc.
- They are immutable, and as such the original unit cannot be accidentaly mutated and will always be copied.

See cunit.benchmarks for more info on speed comparisons.

# Structure
All of cunits units are also constructed of recallable  dimensions. That is to say, every multi-dimensional unit (a unit made of other units) remembers the units used to construct it throughout its lifetime.*
When you create a unit of Speed, it contains every piece that you used to construct it, and these can be re-used and deconstructed at a later date.
e.g.
```csharp
Kilometer distance = 1000;
Hour time = 60;
KilometersPerHour kmph = time * distance;
Console.WriteLine(kmph.XValue); // 60
Console.WriteLine(kmph.YValue); // 1000
```

\* If you generate a Cubed unit from a single value, 2 of those dimensions will be 1. Take care when disassembling multi-units that you create from single values.
```csharp
var mc = new MetersCubed(1000);
Console.WriteLine(mc.XValue); // 1000
Console.WriteLine(mc.YValue); // 1
Console.WriteLine(mc.ZValue); // 1
```

# SI
Everything in cunit is based on SI. Every unit is always a representation of a base SI unit, and every unit can return an SI unit by calling `ToSI()`.  This is implemented in the `IUnit<T>` interface.

#  Flexibility
Cunit has some constants defined, such as tolerance which can be globally modified to allow for a consistent tolerance across your calculations. Cunit also has the unit defined in the generator, so if you need cunit but using float, or decimal. You should be able to change this and rebuild as you require.

# Error Handling
As every unit is a struct you can make some very type safe null free code. Sometimes however, you may hit a scenario where a unit does not exist within this dimension, or you need to return an indication that things didn't go according to plan. Rather than returning a unit with a 0 value that can go undetected cunit has the UnknownUnit which can be explicitly used. There is also UnknownUnit.Err and UnknownUnit.None. If serialization or an operation fails cunit will return one of these two.

# Custom Units
Cunit allows for creating custom units, infact, it is designed with this in mind so that the library doesn't contain every unit vertebrates ever concieved making autocomplete overwhelming.

# Building
cunit is a completely generated library, because I am very lazy, and I think distilling the concept of a unit is much more fun. It also means creating a new unit inside the library will multiply across all existing units.
(This also means errors propagate across every unit, which means errors are consistent)

**To build cunit;**
1. Clone this repo
2. cd into the cloned directory
3. Run dotnet build

### Tips
1. Run dotnet watch for src/generator
2. Run dotnet watch test for tests/cunit.tests at the same time
Modifying cunit files will cause cunit to fully regenerate and run the unit tests

# Contributing
If you wish to contribute to cunit, familiarise yourself with the code generation and how each line affects the units created.
Apologies if the code is currently a tad naff. If this is your first generated code project, fear not! It's a great way to learn.

PRs don't have to be monumental, A PR that does nothing but add a new unit or correct my terrible spelling is still a fantastic PR in my books.

# Other waffle
I hope you enjoy this library, I'm not sure if I can feasibly, or even legally stop you using it to create nuclear warheads, advance late stage capitalism or lobby for further fossil fuel drilling. But if you could just not, I'd really appreciate that. It would cost you $0 to not do that, and you'd even be rewarded with my eternal gratitude.
