namespace cunits.files;

/// <summary>
/// Represents a Microtemperature Unit.
/// </summary>
public readonly struct Microtemperature : IEquatable<Microtemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Microtemperature
	public Microtemperature(double value)
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
	public static implicit operator Microtemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Microtemperature left, Microtemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Microtemperature left, Microtemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Microtemperature left, Microtemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Microtemperature left, Microtemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Microtemperature operator +(Microtemperature val) => val;
	///<inheritdoc/>
	public static Microtemperature operator -(Microtemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Microtemperature left, Microtemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Microtemperature left, Microtemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Microtemperature left, Microtemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Microtemperature left, Microtemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Microtemperature with another Microtemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Microtemperature left, Microtemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Microtemperature with another Microtemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Microtemperature left, Microtemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Microtemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Microtemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


