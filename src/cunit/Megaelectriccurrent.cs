namespace cunits.files;

/// <summary>
/// Represents a Megaelectriccurrent Unit.
/// </summary>
public readonly struct Megaelectriccurrent : IEquatable<Megaelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Megaelectriccurrent
	public Megaelectriccurrent(double value)
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
	public static implicit operator Megaelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Megaelectriccurrent left, Megaelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Megaelectriccurrent left, Megaelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Megaelectriccurrent left, Megaelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Megaelectriccurrent left, Megaelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Megaelectriccurrent operator +(Megaelectriccurrent val) => val;
	///<inheritdoc/>
	public static Megaelectriccurrent operator -(Megaelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Megaelectriccurrent left, Megaelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Megaelectriccurrent left, Megaelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Megaelectriccurrent left, Megaelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Megaelectriccurrent left, Megaelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Megaelectriccurrent with another Megaelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Megaelectriccurrent left, Megaelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Megaelectriccurrent with another Megaelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Megaelectriccurrent left, Megaelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Megaelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Megaelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


