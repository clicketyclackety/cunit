namespace cunits.files;

/// <summary>
/// Represents a Picoluminosity Unit.
/// </summary>
public readonly struct Picoluminosity : IEquatable<Picoluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Picoluminosity
	public Picoluminosity(double value)
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
	public static implicit operator Picoluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Picoluminosity left, Picoluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Picoluminosity left, Picoluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Picoluminosity left, Picoluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Picoluminosity left, Picoluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Picoluminosity operator +(Picoluminosity val) => val;
	///<inheritdoc/>
	public static Picoluminosity operator -(Picoluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Picoluminosity left, Picoluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Picoluminosity left, Picoluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Picoluminosity left, Picoluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Picoluminosity left, Picoluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Picoluminosity with another Picoluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Picoluminosity left, Picoluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Picoluminosity with another Picoluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Picoluminosity left, Picoluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Picoluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Picoluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


