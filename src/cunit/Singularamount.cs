namespace cunits.files;

/// <summary>
/// Represents a Singularamount Unit.
/// </summary>
public readonly struct Singularamount : IEquatable<Singularamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Singularamount
	public Singularamount(double value)
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
	public static implicit operator Singularamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Singularamount left, Singularamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Singularamount left, Singularamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Singularamount left, Singularamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Singularamount left, Singularamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Singularamount operator +(Singularamount val) => val;
	///<inheritdoc/>
	public static Singularamount operator -(Singularamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Singularamount left, Singularamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Singularamount left, Singularamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Singularamount left, Singularamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Singularamount left, Singularamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Singularamount with another Singularamount for equality (no tolerance used)</summary>
	public static bool operator ==(Singularamount left, Singularamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Singularamount with another Singularamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Singularamount left, Singularamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Singularamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Singularamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


