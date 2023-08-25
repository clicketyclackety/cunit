namespace cunits.files;

/// <summary>
/// Represents a Centimeter_Multi Unit.
/// </summary>
public readonly struct Centimeter_Multi : IEquatable<Centimeter_Multi>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Centimeter_Multi
	public Centimeter_Multi(double value)
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
	public static implicit operator Centimeter_Multi(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Centimeter_Multi left, Centimeter_Multi right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Centimeter_Multi left, Centimeter_Multi right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Centimeter_Multi left, Centimeter_Multi right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Centimeter_Multi left, Centimeter_Multi right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Centimeter_Multi operator +(Centimeter_Multi val) => val;
	///<inheritdoc/>
	public static Centimeter_Multi operator -(Centimeter_Multi val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Centimeter_Multi left, Centimeter_Multi right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Centimeter_Multi left, Centimeter_Multi right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Centimeter_Multi left, Centimeter_Multi right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Centimeter_Multi left, Centimeter_Multi right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Centimeter_Multi with another Centimeter_Multi for equality (no tolerance used)</summary>
	public static bool operator ==(Centimeter_Multi left, Centimeter_Multi right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Centimeter_Multi with another Centimeter_Multi for inequality (no tolerance used)</summary>
	public static bool operator !=(Centimeter_Multi left, Centimeter_Multi right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Centimeter_Multi unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Centimeter_Multi unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


