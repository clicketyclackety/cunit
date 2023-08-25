namespace cunits.files;

/// <summary>
/// Represents a Deciluminosity Unit.
/// </summary>
public readonly struct Deciluminosity : IEquatable<Deciluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Deciluminosity
	public Deciluminosity(double value)
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
	public static implicit operator Deciluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Deciluminosity left, Deciluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Deciluminosity left, Deciluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Deciluminosity left, Deciluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Deciluminosity left, Deciluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Deciluminosity operator +(Deciluminosity val) => val;
	///<inheritdoc/>
	public static Deciluminosity operator -(Deciluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Deciluminosity left, Deciluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Deciluminosity left, Deciluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Deciluminosity left, Deciluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Deciluminosity left, Deciluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Deciluminosity with another Deciluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Deciluminosity left, Deciluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Deciluminosity with another Deciluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Deciluminosity left, Deciluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Deciluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Deciluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


