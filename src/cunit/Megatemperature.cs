namespace cunits.files;

/// <summary>
/// Represents a Megatemperature Unit.
/// </summary>
public readonly struct Megatemperature : IEquatable<Megatemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Megatemperature
	public Megatemperature(double value)
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
	public static implicit operator Megatemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Megatemperature left, Megatemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Megatemperature left, Megatemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Megatemperature left, Megatemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Megatemperature left, Megatemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Megatemperature operator +(Megatemperature val) => val;
	///<inheritdoc/>
	public static Megatemperature operator -(Megatemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Megatemperature left, Megatemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Megatemperature left, Megatemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Megatemperature left, Megatemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Megatemperature left, Megatemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Megatemperature with another Megatemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Megatemperature left, Megatemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Megatemperature with another Megatemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Megatemperature left, Megatemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Megatemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Megatemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


