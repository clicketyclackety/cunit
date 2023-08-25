namespace cunits.files;

/// <summary>
/// Represents a Picotemperature Unit.
/// </summary>
public readonly struct Picotemperature : IEquatable<Picotemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Picotemperature
	public Picotemperature(double value)
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
	public static implicit operator Picotemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Picotemperature left, Picotemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Picotemperature left, Picotemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Picotemperature left, Picotemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Picotemperature left, Picotemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Picotemperature operator +(Picotemperature val) => val;
	///<inheritdoc/>
	public static Picotemperature operator -(Picotemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Picotemperature left, Picotemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Picotemperature left, Picotemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Picotemperature left, Picotemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Picotemperature left, Picotemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Picotemperature with another Picotemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Picotemperature left, Picotemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Picotemperature with another Picotemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Picotemperature left, Picotemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Picotemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Picotemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


