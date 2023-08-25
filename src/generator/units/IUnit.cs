using generators.units;

namespace generator.units;

public interface IUnit
{
    public string Name { get; set; }
    public UnitType Type { get; }
    public UnitType[][] CompatibleDimensions { get; }
}

public interface IUnit<T> : IUnit
{
    public double Maximum { get; }
    public double Minimum { get; }
    public double Default { get; }
}