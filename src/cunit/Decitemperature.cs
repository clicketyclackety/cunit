namespace cunits.files;

/// <summary>
/// Represents a Decitemperature Unit.
/// </summary>
public readonly struct Decitemperature : IEquatable<Decitemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decitemperature
	public Decitemperature(double value)
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
	public static implicit operator Decitemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decitemperature left, Decitemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decitemperature left, Decitemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decitemperature left, Decitemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decitemperature left, Decitemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decitemperature operator +(Decitemperature val) => val;
	///<inheritdoc/>
	public static Decitemperature operator -(Decitemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decitemperature left, Decitemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decitemperature left, Decitemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decitemperature left, Decitemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decitemperature left, Decitemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decitemperature with another Decitemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Decitemperature left, Decitemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decitemperature with another Decitemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Decitemperature left, Decitemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decitemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decitemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


