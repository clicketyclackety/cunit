namespace cunits.files;

/// <summary>
/// Represents a Singularluminosity Unit.
/// </summary>
public readonly struct Singularluminosity : IEquatable<Singularluminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Singularluminosity
	public Singularluminosity(double value)
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
	public static implicit operator Singularluminosity(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Singularluminosity left, Singularluminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Singularluminosity left, Singularluminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Singularluminosity left, Singularluminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Singularluminosity left, Singularluminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Singularluminosity operator +(Singularluminosity val) => val;
	///<inheritdoc/>
	public static Singularluminosity operator -(Singularluminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Singularluminosity left, Singularluminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Singularluminosity left, Singularluminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Singularluminosity left, Singularluminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Singularluminosity left, Singularluminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Singularluminosity with another Singularluminosity for equality (no tolerance used)</summary>
	public static bool operator ==(Singularluminosity left, Singularluminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Singularluminosity with another Singularluminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(Singularluminosity left, Singularluminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Singularluminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Singularluminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


