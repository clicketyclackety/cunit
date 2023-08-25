namespace cunits.files;

/// <summary>
/// Represents a Nanoluminosity Unit.
/// </summary>
public readonly struct Nanoluminosity : IEquatable<Nanoluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Nanoluminosity
	public Nanoluminosity(double value)
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
	public static implicit operator Nanoluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Nanoluminosity left, Nanoluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Nanoluminosity left, Nanoluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Nanoluminosity left, Nanoluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Nanoluminosity left, Nanoluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Nanoluminosity operator +(Nanoluminosity val) => val;
	///<inheritdoc/>
	public static Nanoluminosity operator -(Nanoluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Nanoluminosity left, Nanoluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Nanoluminosity left, Nanoluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Nanoluminosity left, Nanoluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Nanoluminosity left, Nanoluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Nanoluminosity with another Nanoluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Nanoluminosity left, Nanoluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Nanoluminosity with another Nanoluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Nanoluminosity left, Nanoluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Nanoluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Nanoluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


