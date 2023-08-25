namespace cunits.files;

/// <summary>
/// Represents a Gigatemperature Unit.
/// </summary>
public readonly struct Gigatemperature : IEquatable<Gigatemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Gigatemperature
	public Gigatemperature(double value)
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
	public static implicit operator Gigatemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Gigatemperature left, Gigatemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Gigatemperature left, Gigatemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Gigatemperature left, Gigatemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Gigatemperature left, Gigatemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Gigatemperature operator +(Gigatemperature val) => val;
	///<inheritdoc/>
	public static Gigatemperature operator -(Gigatemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Gigatemperature left, Gigatemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Gigatemperature left, Gigatemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Gigatemperature left, Gigatemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Gigatemperature left, Gigatemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Gigatemperature with another Gigatemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Gigatemperature left, Gigatemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Gigatemperature with another Gigatemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Gigatemperature left, Gigatemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Gigatemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Gigatemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


