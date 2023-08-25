namespace cunits.files;

/// <summary>
/// Represents a Decielectriccurrent Unit.
/// </summary>
public readonly struct Decielectriccurrent : IEquatable<Decielectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decielectriccurrent
	public Decielectriccurrent(double value)
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
	public static implicit operator Decielectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decielectriccurrent left, Decielectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decielectriccurrent left, Decielectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decielectriccurrent left, Decielectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decielectriccurrent left, Decielectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decielectriccurrent operator +(Decielectriccurrent val) => val;
	///<inheritdoc/>
	public static Decielectriccurrent operator -(Decielectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decielectriccurrent left, Decielectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decielectriccurrent left, Decielectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decielectriccurrent left, Decielectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decielectriccurrent left, Decielectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decielectriccurrent with another Decielectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Decielectriccurrent left, Decielectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decielectriccurrent with another Decielectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Decielectriccurrent left, Decielectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decielectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decielectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


