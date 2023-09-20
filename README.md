# Pre-Preamble
cunit, much like myself, is a work in progress. It shouldn't be considered a stable API yet, and for a lot of the code (currently) it's not correct. If you would like to help cunit get to that stage, please read the contributing section.

# Preamble
cunit is a general units library for C#. I've found other unit libraries to have the following issues that have always bothered me;
- Large (1-2mb+)
- Long, inefficient syntax
- Hard to use
- Class based, introducing nullables into maths 🤢
- Mutable

As such cunit is designed to be a lightweight, efficient, intuitive and immutable alternative.

Let's start with a simple example dealing with temperature.
```c#
Farenheight f = 40;
Celcius c = 32;
Kelvin k = (c - f) * 2;
```
We quickly see that cunit is designed to work like and alongside doubles. There are no methods to cast one measurement into another, it happens seamlessly. The only thing cunit **does not** cast to is a double. You must explicitly call `myUnit.Value` as an example. I believe casting these units to doubles implicitly will cause all sorts of weird issues in calculations, and I'd rather avoid that.


# Performance
All of cunits units are readonly structs that are entirely precomputed. That is to say, once your unit is created, GetHashCode() has no overhead, nor does ToString(), the Value or any operation that is internal to the structure. (Equals and == of course perform a calculation). Every operation you perform with cunit takes place in the stack.


# Structure
All of cunits units are also constructed of recallable  dimensions. That is to say, every multi-dimensional unit (a unit made of other units) remembers the units used to construct it throughout its lifetime.*
When you create a unit of Speed, it contains every piece that you used to construct it.
e.g.
```c#
Kilometer distance = 1000;
Hour time = 60;
KilometersPerHour = time * distance;
Console.WriteLine(time.XValue);
Console.WriteLine(time.YValue);
```

* If you generate a Cubed unit from a single value, 2 of those dimensions will be 1.


# SI
Everything in cunit is based on SI. Every unit is always a representation of a base SI unit, and any unit can be converted to SI by calling `ToSI()`. 


# Building
cunit is a completely (99%) generated library, because I am very lazy, and I think distilling the concept of a unit is much more fun. It also means creating a new unit inside the library will multiply across all existing units.
(This also means errors propagate across every unit, which means errors are consistent)
**To build cunit;**
1. Clone this repo
2. Use build in visual studio. CUnit will be generated
3. Manually select cunit and call for it to build
4. You now have a copy of cunit.


### Flexibility
cunit has some constants defined, such as tolerance which can be globally modified to allow for a consistent tolerance across your calculations. (In the future I may offer a tolerance input).
cunit also has the unit defined in the generator, so if you need cunit but using float, or decimal. You should be able to change this and rebuild as you require.


# Contributing
If you wish to contribute to cunit, familiarise yourself with the code generation and how each line affects the units created.
Apologies if the code is currently a tad naff. If this is your first generated code project, fear not! It's a great way to learn.

PRs don't have to be monumental, A PR that does nothing but add a new unit or correct my terrible spelling is still a fantastic PR in my books.


# Other waffle
I hope you enjoy this library, I'm not sure if I can feasibly, or even legally stop you using it to create nuclear warheads, advance late stage capitalism or lobby for further fossil fuel drilling. But if you could just not, I'd really appreciate that. It would cost you $0 to not.