namespace cunits.files;

/// <summary>
/// Represents a Hectoelectriccurrent Unit.
/// </summary>
public readonly struct Hectoelectriccurrent : IEquatable<Hectoelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Hectoelectriccurrent
	public Hectoelectriccurrent(double value)
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
	public static implicit operator Hectoelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Hectoelectriccurrent left, Hectoelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Hectoelectriccurrent left, Hectoelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Hectoelectriccurrent left, Hectoelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Hectoelectriccurrent left, Hectoelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Hectoelectriccurrent operator +(Hectoelectriccurrent val) => val;
	///<inheritdoc/>
	public static Hectoelectriccurrent operator -(Hectoelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Hectoelectriccurrent left, Hectoelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Hectoelectriccurrent left, Hectoelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Hectoelectriccurrent left, Hectoelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Hectoelectriccurrent left, Hectoelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Hectoelectriccurrent with another Hectoelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Hectoelectriccurrent left, Hectoelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Hectoelectriccurrent with another Hectoelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Hectoelectriccurrent left, Hectoelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Hectoelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Hectoelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


