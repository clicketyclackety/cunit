namespace cunits.files;

/// <summary>
/// Represents a Millitemperature Unit.
/// </summary>
public readonly struct Millitemperature : IEquatable<Millitemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Millitemperature
	public Millitemperature(double value)
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
	public static implicit operator Millitemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Millitemperature left, Millitemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Millitemperature left, Millitemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Millitemperature left, Millitemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Millitemperature left, Millitemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Millitemperature operator +(Millitemperature val) => val;
	///<inheritdoc/>
	public static Millitemperature operator -(Millitemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Millitemperature left, Millitemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Millitemperature left, Millitemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Millitemperature left, Millitemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Millitemperature left, Millitemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Millitemperature with another Millitemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Millitemperature left, Millitemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Millitemperature with another Millitemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Millitemperature left, Millitemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Millitemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Millitemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


