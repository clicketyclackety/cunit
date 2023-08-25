namespace cunits.files;

/// <summary>
/// Represents a Singulartemperature Unit.
/// </summary>
public readonly struct Singulartemperature : IEquatable<Singulartemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Singulartemperature
	public Singulartemperature(double value)
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
	public static implicit operator Singulartemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Singulartemperature left, Singulartemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Singulartemperature left, Singulartemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Singulartemperature left, Singulartemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Singulartemperature left, Singulartemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Singulartemperature operator +(Singulartemperature val) => val;
	///<inheritdoc/>
	public static Singulartemperature operator -(Singulartemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Singulartemperature left, Singulartemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Singulartemperature left, Singulartemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Singulartemperature left, Singulartemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Singulartemperature left, Singulartemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Singulartemperature with another Singulartemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Singulartemperature left, Singulartemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Singulartemperature with another Singulartemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Singulartemperature left, Singulartemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Singulartemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Singulartemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


