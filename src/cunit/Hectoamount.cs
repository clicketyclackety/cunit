namespace cunits.files;

/// <summary>
/// Represents a Hectoamount Unit.
/// </summary>
public readonly struct Hectoamount : IEquatable<Hectoamount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Hectoamount
	public Hectoamount(double value)
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
	public static implicit operator Hectoamount(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Hectoamount left, Hectoamount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Hectoamount left, Hectoamount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Hectoamount left, Hectoamount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Hectoamount left, Hectoamount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Hectoamount operator +(Hectoamount val) => val;
	///<inheritdoc/>
	public static Hectoamount operator -(Hectoamount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Hectoamount left, Hectoamount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Hectoamount left, Hectoamount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Hectoamount left, Hectoamount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Hectoamount left, Hectoamount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Hectoamount with another Hectoamount for equality (no tolerance used)</summary>
	public static bool operator ==(Hectoamount left, Hectoamount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Hectoamount with another Hectoamount for inequality (no tolerance used)</summary>
	public static bool operator !=(Hectoamount left, Hectoamount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Hectoamount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Hectoamount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


