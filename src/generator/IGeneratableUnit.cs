using generator.units;

namespace generators;

public interface IGeneratableUnit : IGeneratable, IUnit
{
    public string UnitSymbol { get; }
    public string DimensionSymbol { get; }
    public string ValueType { get; }
    public string DefaultValue { get; }
}
