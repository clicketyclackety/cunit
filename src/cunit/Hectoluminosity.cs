namespace cunits.files;

/// <summary>
/// Represents a Hectoluminosity Unit.
/// </summary>
public readonly struct Hectoluminosity : IEquatable<Hectoluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Hectoluminosity
	public Hectoluminosity(double value)
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
	public static implicit operator Hectoluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Hectoluminosity left, Hectoluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Hectoluminosity left, Hectoluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Hectoluminosity left, Hectoluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Hectoluminosity left, Hectoluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Hectoluminosity operator +(Hectoluminosity val) => val;
	///<inheritdoc/>
	public static Hectoluminosity operator -(Hectoluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Hectoluminosity left, Hectoluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Hectoluminosity left, Hectoluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Hectoluminosity left, Hectoluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Hectoluminosity left, Hectoluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Hectoluminosity with another Hectoluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Hectoluminosity left, Hectoluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Hectoluminosity with another Hectoluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Hectoluminosity left, Hectoluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Hectoluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Hectoluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


