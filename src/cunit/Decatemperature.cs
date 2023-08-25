namespace cunits.files;

/// <summary>
/// Represents a Decatemperature Unit.
/// </summary>
public readonly struct Decatemperature : IEquatable<Decatemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decatemperature
	public Decatemperature(double value)
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
	public static implicit operator Decatemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decatemperature left, Decatemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decatemperature left, Decatemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decatemperature left, Decatemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decatemperature left, Decatemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decatemperature operator +(Decatemperature val) => val;
	///<inheritdoc/>
	public static Decatemperature operator -(Decatemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decatemperature left, Decatemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decatemperature left, Decatemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decatemperature left, Decatemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decatemperature left, Decatemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decatemperature with another Decatemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Decatemperature left, Decatemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decatemperature with another Decatemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Decatemperature left, Decatemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decatemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decatemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


