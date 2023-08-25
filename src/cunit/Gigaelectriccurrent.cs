namespace cunits.files;

/// <summary>
/// Represents a Gigaelectriccurrent Unit.
/// </summary>
public readonly struct Gigaelectriccurrent : IEquatable<Gigaelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Gigaelectriccurrent
	public Gigaelectriccurrent(double value)
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
	public static implicit operator Gigaelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Gigaelectriccurrent left, Gigaelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Gigaelectriccurrent left, Gigaelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Gigaelectriccurrent left, Gigaelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Gigaelectriccurrent left, Gigaelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Gigaelectriccurrent operator +(Gigaelectriccurrent val) => val;
	///<inheritdoc/>
	public static Gigaelectriccurrent operator -(Gigaelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Gigaelectriccurrent left, Gigaelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Gigaelectriccurrent left, Gigaelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Gigaelectriccurrent left, Gigaelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Gigaelectriccurrent left, Gigaelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Gigaelectriccurrent with another Gigaelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Gigaelectriccurrent left, Gigaelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Gigaelectriccurrent with another Gigaelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Gigaelectriccurrent left, Gigaelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Gigaelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Gigaelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


