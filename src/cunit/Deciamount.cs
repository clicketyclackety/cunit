namespace cunits.files;

/// <summary>
/// Represents a Deciamount Unit.
/// </summary>
public readonly struct Deciamount : IEquatable<Deciamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Deciamount
	public Deciamount(double value)
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
	public static implicit operator Deciamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Deciamount left, Deciamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Deciamount left, Deciamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Deciamount left, Deciamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Deciamount left, Deciamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Deciamount operator +(Deciamount val) => val;
	///<inheritdoc/>
	public static Deciamount operator -(Deciamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Deciamount left, Deciamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Deciamount left, Deciamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Deciamount left, Deciamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Deciamount left, Deciamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Deciamount with another Deciamount for equality (no tolerance used)</summary>
	public static bool operator ==(Deciamount left, Deciamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Deciamount with another Deciamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Deciamount left, Deciamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Deciamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Deciamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


