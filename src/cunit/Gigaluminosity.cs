namespace cunits.files;

/// <summary>
/// Represents a Gigaluminosity Unit.
/// </summary>
public readonly struct Gigaluminosity : IEquatable<Gigaluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Gigaluminosity
	public Gigaluminosity(double value)
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
	public static implicit operator Gigaluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Gigaluminosity left, Gigaluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Gigaluminosity left, Gigaluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Gigaluminosity left, Gigaluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Gigaluminosity left, Gigaluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Gigaluminosity operator +(Gigaluminosity val) => val;
	///<inheritdoc/>
	public static Gigaluminosity operator -(Gigaluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Gigaluminosity left, Gigaluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Gigaluminosity left, Gigaluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Gigaluminosity left, Gigaluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Gigaluminosity left, Gigaluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Gigaluminosity with another Gigaluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Gigaluminosity left, Gigaluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Gigaluminosity with another Gigaluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Gigaluminosity left, Gigaluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Gigaluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Gigaluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


