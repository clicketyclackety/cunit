namespace cunits.files;

/// <summary>
/// Represents a Decaamount Unit.
/// </summary>
public readonly struct Decaamount : IEquatable<Decaamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decaamount
	public Decaamount(double value)
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
	public static implicit operator Decaamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decaamount left, Decaamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decaamount left, Decaamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decaamount left, Decaamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decaamount left, Decaamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decaamount operator +(Decaamount val) => val;
	///<inheritdoc/>
	public static Decaamount operator -(Decaamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decaamount left, Decaamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decaamount left, Decaamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decaamount left, Decaamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decaamount left, Decaamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decaamount with another Decaamount for equality (no tolerance used)</summary>
	public static bool operator ==(Decaamount left, Decaamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decaamount with another Decaamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Decaamount left, Decaamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decaamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decaamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


