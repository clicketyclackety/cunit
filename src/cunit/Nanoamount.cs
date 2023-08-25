namespace cunits.files;

/// <summary>
/// Represents a Nanoamount Unit.
/// </summary>
public readonly struct Nanoamount : IEquatable<Nanoamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Nanoamount
	public Nanoamount(double value)
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
	public static implicit operator Nanoamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Nanoamount left, Nanoamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Nanoamount left, Nanoamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Nanoamount left, Nanoamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Nanoamount left, Nanoamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Nanoamount operator +(Nanoamount val) => val;
	///<inheritdoc/>
	public static Nanoamount operator -(Nanoamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Nanoamount left, Nanoamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Nanoamount left, Nanoamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Nanoamount left, Nanoamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Nanoamount left, Nanoamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Nanoamount with another Nanoamount for equality (no tolerance used)</summary>
	public static bool operator ==(Nanoamount left, Nanoamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Nanoamount with another Nanoamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Nanoamount left, Nanoamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Nanoamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Nanoamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


