namespace cunits.files;

/// <summary>
/// Represents a Microluminosity Unit.
/// </summary>
public readonly struct Microluminosity : IEquatable<Microluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Microluminosity
	public Microluminosity(double value)
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
	public static implicit operator Microluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Microluminosity left, Microluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Microluminosity left, Microluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Microluminosity left, Microluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Microluminosity left, Microluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Microluminosity operator +(Microluminosity val) => val;
	///<inheritdoc/>
	public static Microluminosity operator -(Microluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Microluminosity left, Microluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Microluminosity left, Microluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Microluminosity left, Microluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Microluminosity left, Microluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Microluminosity with another Microluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Microluminosity left, Microluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Microluminosity with another Microluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Microluminosity left, Microluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Microluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Microluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


