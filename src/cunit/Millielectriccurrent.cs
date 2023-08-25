namespace cunits.files;

/// <summary>
/// Represents a Millielectriccurrent Unit.
/// </summary>
public readonly struct Millielectriccurrent : IEquatable<Millielectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Millielectriccurrent
	public Millielectriccurrent(double value)
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
	public static implicit operator Millielectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Millielectriccurrent left, Millielectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Millielectriccurrent left, Millielectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Millielectriccurrent left, Millielectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Millielectriccurrent left, Millielectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Millielectriccurrent operator +(Millielectriccurrent val) => val;
	///<inheritdoc/>
	public static Millielectriccurrent operator -(Millielectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Millielectriccurrent left, Millielectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Millielectriccurrent left, Millielectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Millielectriccurrent left, Millielectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Millielectriccurrent left, Millielectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Millielectriccurrent with another Millielectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Millielectriccurrent left, Millielectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Millielectriccurrent with another Millielectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Millielectriccurrent left, Millielectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Millielectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Millielectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


