namespace cunits.files;

/// <summary>
/// Represents a Petatemperature Unit.
/// </summary>
public readonly struct Petatemperature : IEquatable<Petatemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Petatemperature
	public Petatemperature(double value)
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
	public static implicit operator Petatemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Petatemperature left, Petatemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Petatemperature left, Petatemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Petatemperature left, Petatemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Petatemperature left, Petatemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Petatemperature operator +(Petatemperature val) => val;
	///<inheritdoc/>
	public static Petatemperature operator -(Petatemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Petatemperature left, Petatemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Petatemperature left, Petatemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Petatemperature left, Petatemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Petatemperature left, Petatemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Petatemperature with another Petatemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Petatemperature left, Petatemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Petatemperature with another Petatemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Petatemperature left, Petatemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Petatemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Petatemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


