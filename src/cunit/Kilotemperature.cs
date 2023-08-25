namespace cunits.files;

/// <summary>
/// Represents a Kilotemperature Unit.
/// </summary>
public readonly struct Kilotemperature : IEquatable<Kilotemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Kilotemperature
	public Kilotemperature(double value)
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
	public static implicit operator Kilotemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Kilotemperature left, Kilotemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Kilotemperature left, Kilotemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Kilotemperature left, Kilotemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Kilotemperature left, Kilotemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Kilotemperature operator +(Kilotemperature val) => val;
	///<inheritdoc/>
	public static Kilotemperature operator -(Kilotemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Kilotemperature left, Kilotemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Kilotemperature left, Kilotemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Kilotemperature left, Kilotemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Kilotemperature left, Kilotemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Kilotemperature with another Kilotemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Kilotemperature left, Kilotemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Kilotemperature with another Kilotemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Kilotemperature left, Kilotemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Kilotemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Kilotemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


