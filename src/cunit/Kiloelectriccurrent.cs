namespace cunits.files;

/// <summary>
/// Represents a Kiloelectriccurrent Unit.
/// </summary>
public readonly struct Kiloelectriccurrent : IEquatable<Kiloelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Kiloelectriccurrent
	public Kiloelectriccurrent(double value)
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
	public static implicit operator Kiloelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Kiloelectriccurrent left, Kiloelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Kiloelectriccurrent left, Kiloelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Kiloelectriccurrent left, Kiloelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Kiloelectriccurrent left, Kiloelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Kiloelectriccurrent operator +(Kiloelectriccurrent val) => val;
	///<inheritdoc/>
	public static Kiloelectriccurrent operator -(Kiloelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Kiloelectriccurrent left, Kiloelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Kiloelectriccurrent left, Kiloelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Kiloelectriccurrent left, Kiloelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Kiloelectriccurrent left, Kiloelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Kiloelectriccurrent with another Kiloelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Kiloelectriccurrent left, Kiloelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Kiloelectriccurrent with another Kiloelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Kiloelectriccurrent left, Kiloelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Kiloelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Kiloelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


