namespace cunit;

/// <summary>Defines a Unit</summary>
public interface IUnit
{
    /// <summary>The numeric value of this unit</summary>
    public double Value { get; }
}

/// <summary>Defines a Unit with SI Conversion</summary>
public interface IUnit<TSi> : IUnit
{
    /// <summary>Converts to an SI Unit</summary>
    /// <returns>An SI Unit</returns>
    public TSi ToSI();
}

/// <summary>Defines a 2D Unit</summary>
public interface IUnit<XUnit, YUnit> : IUnit
{
    /// <summary>X Dimension Unit</summary>
    public XUnit XValue { get; }
    /// <summary>Y Dimension Unit</summary>
    public YUnit YValue { get; }
}

/// <summary>Defines a 3D Unit</summary>
public interface IUnit<XUnit, YUnit, ZUnit>
    : IUnit<XUnit, YUnit>
{
    /// <summary>Z Dimension Unit</summary>
    public ZUnit ZValue { get; }
}

/// <summary>Defines a 4D Unit</summary>
public interface IUnit<XUnit, YUnit, ZUnit, UUnit> 
    : IUnit<XUnit, YUnit, ZUnit>
{
    /// <summary>U Dimension Unit</summary>
    public UUnit UValue { get; }
}

/// <summary>Defines a 5D Unit</summary>
public interface IUnit<XUnit, YUnit, ZUnit, UUnit, VUnit> 
    : IUnit<XUnit, YUnit, ZUnit, UUnit>
{
    /// <summary>V Dimension Unit</summary>
    public VUnit VValue { get; }
}

/// <summary>Defines a 6D Unit</summary>
public interface IUnit<XUnit, YUnit, ZUnit, UUnit, VUnit, WUnit> 
    : IUnit<XUnit, YUnit, ZUnit, UUnit, VUnit>
{
    /// <summary>W Dimension Unit</summary>
    public WUnit WValue { get; }
}