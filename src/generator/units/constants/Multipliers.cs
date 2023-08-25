namespace generator.units.constants;

// https://en.wikipedia.org/wiki/Micro-
public static class BaseTenPrefixes
{
    [Symbol("P")]
    public const double Peta = 1_000_000_000_000_000;
    
    [Symbol("T")]
    public const double Tera = 1_000_000_000_000;
    
    [Symbol("G")]
    public const double Giga = 1_000_000_000;
    
    [Symbol("M")]
    public const double Mega = 1_000_000;
    
    [Symbol("k")]
    public const double Kilo = 1_000;
    
    [Symbol("h")]
    public const double Hecto = 100;
    
    [Symbol("da")]
    public const double Deca = 10;
    
    [Symbol("")]
    public const double Singular = 1;
    
    [Symbol("d")]
    public const double Deci = 0.1;
    
    [Symbol("c")]
    public const double Centi = 0.01;
    
    [Symbol("m")]
    public const double Milli = 0.001;
    
    [Symbol("μ")]
    public const double Micro = 0.000_001;
    
    [Symbol("n")]
    public const double Pico = 0.000_000_000_001;
    
    [Symbol("p")]
    public const double Nano = 0.000_000_001;

    public static double ToTera(this double value) => value * Tera;
    public static double ToGiga(this double value) => value * Giga;
    public static double ToMega(this double value) => value * Mega;
    public static double ToKilo(this double value) => value * Kilo;
    public static double ToHecto(this double value) => value * Hecto;
    public static double ToDeca(this double value) => value * Deca;

    public static double ToSingular(this double value) => value * Singular;
    
    public static double ToDeci(this double value) => value * Deci;
    public static double ToCenti(this double value) => value * Centi;
    public static double ToMilli(this double value) => value * Milli;
    public static double ToMicro(this double value) => value * Micro;
    public static double ToPico(this double value) => value * Pico;
    public static double ToNano(this double value) => value * Nano;
}

public static class BaseSixtyPrefixes
{
    // public const 
}

public class SymbolAttribute : Attribute
{

    internal readonly string _symbol;
    
    public SymbolAttribute(string symbol)
    {
        _symbol = symbol;
    }
}