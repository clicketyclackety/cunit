namespace cunits.files;

/// <summary>
/// Represents a Milliluminosity Unit.
/// </summary>
public readonly struct Milliluminosity : IEquatable<Milliluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Milliluminosity
	public Milliluminosity(double value)
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
	public static implicit operator Milliluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Milliluminosity left, Milliluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Milliluminosity left, Milliluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Milliluminosity left, Milliluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Milliluminosity left, Milliluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Milliluminosity operator +(Milliluminosity val) => val;
	///<inheritdoc/>
	public static Milliluminosity operator -(Milliluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Milliluminosity left, Milliluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Milliluminosity left, Milliluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Milliluminosity left, Milliluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Milliluminosity left, Milliluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Milliluminosity with another Milliluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Milliluminosity left, Milliluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Milliluminosity with another Milliluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Milliluminosity left, Milliluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Milliluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Milliluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


