namespace cunits.files;

/// <summary>
/// Represents a Teraluminosity Unit.
/// </summary>
public readonly struct Teraluminosity : IEquatable<Teraluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Teraluminosity
	public Teraluminosity(double value)
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
	public static implicit operator Teraluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Teraluminosity left, Teraluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Teraluminosity left, Teraluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Teraluminosity left, Teraluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Teraluminosity left, Teraluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Teraluminosity operator +(Teraluminosity val) => val;
	///<inheritdoc/>
	public static Teraluminosity operator -(Teraluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Teraluminosity left, Teraluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Teraluminosity left, Teraluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Teraluminosity left, Teraluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Teraluminosity left, Teraluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Teraluminosity with another Teraluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Teraluminosity left, Teraluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Teraluminosity with another Teraluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Teraluminosity left, Teraluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Teraluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Teraluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


