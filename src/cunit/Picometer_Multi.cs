namespace cunits.files;

/// <summary>
/// Represents a Picometer_Multi Unit.
/// </summary>
public readonly struct Picometer_Multi : IEquatable<Picometer_Multi>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Picometer_Multi
	public Picometer_Multi(double value)
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
	public static implicit operator Picometer_Multi(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Picometer_Multi left, Picometer_Multi right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Picometer_Multi left, Picometer_Multi right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Picometer_Multi left, Picometer_Multi right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Picometer_Multi left, Picometer_Multi right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Picometer_Multi operator +(Picometer_Multi val) => val;
	///<inheritdoc/>
	public static Picometer_Multi operator -(Picometer_Multi val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Picometer_Multi left, Picometer_Multi right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Picometer_Multi left, Picometer_Multi right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Picometer_Multi left, Picometer_Multi right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Picometer_Multi left, Picometer_Multi right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Picometer_Multi with another Picometer_Multi for equality (no tolerance used)</summary>
	public static bool operator ==(Picometer_Multi left, Picometer_Multi right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Picometer_Multi with another Picometer_Multi for inequality (no tolerance used)</summary>
	public static bool operator !=(Picometer_Multi left, Picometer_Multi right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Picometer_Multi unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Picometer_Multi unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


