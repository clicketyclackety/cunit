namespace cunits.files;

/// <summary>
/// Represents a Centiamount Unit.
/// </summary>
public readonly struct Centiamount : IEquatable<Centiamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Centiamount
	public Centiamount(double value)
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
	public static implicit operator Centiamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Centiamount left, Centiamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Centiamount left, Centiamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Centiamount left, Centiamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Centiamount left, Centiamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Centiamount operator +(Centiamount val) => val;
	///<inheritdoc/>
	public static Centiamount operator -(Centiamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Centiamount left, Centiamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Centiamount left, Centiamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Centiamount left, Centiamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Centiamount left, Centiamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Centiamount with another Centiamount for equality (no tolerance used)</summary>
	public static bool operator ==(Centiamount left, Centiamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Centiamount with another Centiamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Centiamount left, Centiamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Centiamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Centiamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


