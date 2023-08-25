namespace cunits.files;

/// <summary>
/// Represents a Decaluminosity Unit.
/// </summary>
public readonly struct Decaluminosity : IEquatable<Decaluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decaluminosity
	public Decaluminosity(double value)
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
	public static implicit operator Decaluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decaluminosity left, Decaluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decaluminosity left, Decaluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decaluminosity left, Decaluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decaluminosity left, Decaluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decaluminosity operator +(Decaluminosity val) => val;
	///<inheritdoc/>
	public static Decaluminosity operator -(Decaluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decaluminosity left, Decaluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decaluminosity left, Decaluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decaluminosity left, Decaluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decaluminosity left, Decaluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decaluminosity with another Decaluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Decaluminosity left, Decaluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decaluminosity with another Decaluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Decaluminosity left, Decaluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decaluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decaluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


