namespace cunits.files;

/// <summary>
/// Represents a Picoamount Unit.
/// </summary>
public readonly struct Picoamount : IEquatable<Picoamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Picoamount
	public Picoamount(double value)
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
	public static implicit operator Picoamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Picoamount left, Picoamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Picoamount left, Picoamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Picoamount left, Picoamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Picoamount left, Picoamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Picoamount operator +(Picoamount val) => val;
	///<inheritdoc/>
	public static Picoamount operator -(Picoamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Picoamount left, Picoamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Picoamount left, Picoamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Picoamount left, Picoamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Picoamount left, Picoamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Picoamount with another Picoamount for equality (no tolerance used)</summary>
	public static bool operator ==(Picoamount left, Picoamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Picoamount with another Picoamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Picoamount left, Picoamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Picoamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Picoamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


