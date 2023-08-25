namespace cunits.files;

/// <summary>
/// Represents a Nanometer_Multi Unit.
/// </summary>
public readonly struct Nanometer_Multi : IEquatable<Nanometer_Multi>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Nanometer_Multi
	public Nanometer_Multi(double value)
	{
		Value = value;
	}

	#region Methods

	/// <summary>Converts a unit to SI</summary>
	public Meter ToSI() => (Meter)this;

	#endregion

	#region Operators

	#region Casting

	/// <summary>Converts a double into this Unit.</summary>
	public static implicit operator Nanometer_Multi(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Nanometer_Multi left, Nanometer_Multi right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Nanometer_Multi left, Nanometer_Multi right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Nanometer_Multi left, Nanometer_Multi right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Nanometer_Multi left, Nanometer_Multi right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Nanometer_Multi operator +(Nanometer_Multi val) => val;
	///<inheritdoc/>
	public static Nanometer_Multi operator -(Nanometer_Multi val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Nanometer_Multi left, Nanometer_Multi right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Nanometer_Multi left, Nanometer_Multi right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Nanometer_Multi left, Nanometer_Multi right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Nanometer_Multi left, Nanometer_Multi right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Nanometer_Multi with another Nanometer_Multi for equality (no tolerance used)</summary>
	public static bool operator ==(Nanometer_Multi left, Nanometer_Multi right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Nanometer_Multi with another Nanometer_Multi for inequality (no tolerance used)</summary>
	public static bool operator !=(Nanometer_Multi left, Nanometer_Multi right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Nanometer_Multi unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Nanometer_Multi unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


