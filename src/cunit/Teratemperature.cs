namespace cunits.files;

/// <summary>
/// Represents a Teratemperature Unit.
/// </summary>
public readonly struct Teratemperature : IEquatable<Teratemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Teratemperature
	public Teratemperature(double value)
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
	public static implicit operator Teratemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Teratemperature left, Teratemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Teratemperature left, Teratemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Teratemperature left, Teratemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Teratemperature left, Teratemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Teratemperature operator +(Teratemperature val) => val;
	///<inheritdoc/>
	public static Teratemperature operator -(Teratemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Teratemperature left, Teratemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Teratemperature left, Teratemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Teratemperature left, Teratemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Teratemperature left, Teratemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Teratemperature with another Teratemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Teratemperature left, Teratemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Teratemperature with another Teratemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Teratemperature left, Teratemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Teratemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Teratemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


