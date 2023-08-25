namespace cunits.files;

/// <summary>
/// Represents a Centitemperature Unit.
/// </summary>
public readonly struct Centitemperature : IEquatable<Centitemperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Centitemperature
	public Centitemperature(double value)
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
	public static implicit operator Centitemperature(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Centitemperature left, Centitemperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Centitemperature left, Centitemperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Centitemperature left, Centitemperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Centitemperature left, Centitemperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Centitemperature operator +(Centitemperature val) => val;
	///<inheritdoc/>
	public static Centitemperature operator -(Centitemperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Centitemperature left, Centitemperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Centitemperature left, Centitemperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Centitemperature left, Centitemperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Centitemperature left, Centitemperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Centitemperature with another Centitemperature for equality (no tolerance used)</summary>
	public static bool operator ==(Centitemperature left, Centitemperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Centitemperature with another Centitemperature for inequality (no tolerance used)</summary>
	public static bool operator !=(Centitemperature left, Centitemperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Centitemperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Centitemperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


