namespace cunits.files;

/// <summary>
/// Represents a Centiluminosity Unit.
/// </summary>
public readonly struct Centiluminosity : IEquatable<Centiluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Centiluminosity
	public Centiluminosity(double value)
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
	public static implicit operator Centiluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Centiluminosity left, Centiluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Centiluminosity left, Centiluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Centiluminosity left, Centiluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Centiluminosity left, Centiluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Centiluminosity operator +(Centiluminosity val) => val;
	///<inheritdoc/>
	public static Centiluminosity operator -(Centiluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Centiluminosity left, Centiluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Centiluminosity left, Centiluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Centiluminosity left, Centiluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Centiluminosity left, Centiluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Centiluminosity with another Centiluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Centiluminosity left, Centiluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Centiluminosity with another Centiluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Centiluminosity left, Centiluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Centiluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Centiluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


