namespace generator.units;

public record struct UnitRange(double Start, double End)
{
    public readonly bool Inside(double value) => value >= Start && value <= End;
}
