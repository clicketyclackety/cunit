namespace cunits.files;

/// <summary>
/// Represents a Microamount Unit.
/// </summary>
public readonly struct Microamount : IEquatable<Microamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Microamount
	public Microamount(double value)
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
	public static implicit operator Microamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Microamount left, Microamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Microamount left, Microamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Microamount left, Microamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Microamount left, Microamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Microamount operator +(Microamount val) => val;
	///<inheritdoc/>
	public static Microamount operator -(Microamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Microamount left, Microamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Microamount left, Microamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Microamount left, Microamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Microamount left, Microamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Microamount with another Microamount for equality (no tolerance used)</summary>
	public static bool operator ==(Microamount left, Microamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Microamount with another Microamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Microamount left, Microamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Microamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Microamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


