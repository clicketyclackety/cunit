namespace cunits.files;

/// <summary>
/// Represents a Petaluminosity Unit.
/// </summary>
public readonly struct Petaluminosity : IEquatable<Petaluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Petaluminosity
	public Petaluminosity(double value)
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
	public static implicit operator Petaluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Petaluminosity left, Petaluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Petaluminosity left, Petaluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Petaluminosity left, Petaluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Petaluminosity left, Petaluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Petaluminosity operator +(Petaluminosity val) => val;
	///<inheritdoc/>
	public static Petaluminosity operator -(Petaluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Petaluminosity left, Petaluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Petaluminosity left, Petaluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Petaluminosity left, Petaluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Petaluminosity left, Petaluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Petaluminosity with another Petaluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Petaluminosity left, Petaluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Petaluminosity with another Petaluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Petaluminosity left, Petaluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Petaluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Petaluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


