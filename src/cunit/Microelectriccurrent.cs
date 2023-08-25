namespace cunits.files;

/// <summary>
/// Represents a Microelectriccurrent Unit.
/// </summary>
public readonly struct Microelectriccurrent : IEquatable<Microelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Microelectriccurrent
	public Microelectriccurrent(double value)
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
	public static implicit operator Microelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Microelectriccurrent left, Microelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Microelectriccurrent left, Microelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Microelectriccurrent left, Microelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Microelectriccurrent left, Microelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Microelectriccurrent operator +(Microelectriccurrent val) => val;
	///<inheritdoc/>
	public static Microelectriccurrent operator -(Microelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Microelectriccurrent left, Microelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Microelectriccurrent left, Microelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Microelectriccurrent left, Microelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Microelectriccurrent left, Microelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Microelectriccurrent with another Microelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Microelectriccurrent left, Microelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Microelectriccurrent with another Microelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Microelectriccurrent left, Microelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Microelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Microelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


