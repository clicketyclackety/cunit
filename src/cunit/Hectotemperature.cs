namespace cunits.files;

/// <summary>
/// Represents a Hectotemperature Unit.
/// </summary>
public readonly struct Hectotemperature : IEquatable<Hectotemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Hectotemperature
	public Hectotemperature(double value)
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
	public static implicit operator Hectotemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Hectotemperature left, Hectotemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Hectotemperature left, Hectotemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Hectotemperature left, Hectotemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Hectotemperature left, Hectotemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Hectotemperature operator +(Hectotemperature val) => val;
	///<inheritdoc/>
	public static Hectotemperature operator -(Hectotemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Hectotemperature left, Hectotemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Hectotemperature left, Hectotemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Hectotemperature left, Hectotemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Hectotemperature left, Hectotemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Hectotemperature with another Hectotemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Hectotemperature left, Hectotemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Hectotemperature with another Hectotemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Hectotemperature left, Hectotemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Hectotemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Hectotemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


