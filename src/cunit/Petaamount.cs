namespace cunits.files;

/// <summary>
/// Represents a Petaamount Unit.
/// </summary>
public readonly struct Petaamount : IEquatable<Petaamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Petaamount
	public Petaamount(double value)
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
	public static implicit operator Petaamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Petaamount left, Petaamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Petaamount left, Petaamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Petaamount left, Petaamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Petaamount left, Petaamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Petaamount operator +(Petaamount val) => val;
	///<inheritdoc/>
	public static Petaamount operator -(Petaamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Petaamount left, Petaamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Petaamount left, Petaamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Petaamount left, Petaamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Petaamount left, Petaamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Petaamount with another Petaamount for equality (no tolerance used)</summary>
	public static bool operator ==(Petaamount left, Petaamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Petaamount with another Petaamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Petaamount left, Petaamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Petaamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Petaamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


