namespace cunits.files;

/// <summary>
/// Represents a Megaamount Unit.
/// </summary>
public readonly struct Megaamount : IEquatable<Megaamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Megaamount
	public Megaamount(double value)
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
	public static implicit operator Megaamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Megaamount left, Megaamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Megaamount left, Megaamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Megaamount left, Megaamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Megaamount left, Megaamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Megaamount operator +(Megaamount val) => val;
	///<inheritdoc/>
	public static Megaamount operator -(Megaamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Megaamount left, Megaamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Megaamount left, Megaamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Megaamount left, Megaamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Megaamount left, Megaamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Megaamount with another Megaamount for equality (no tolerance used)</summary>
	public static bool operator ==(Megaamount left, Megaamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Megaamount with another Megaamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Megaamount left, Megaamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Megaamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Megaamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


